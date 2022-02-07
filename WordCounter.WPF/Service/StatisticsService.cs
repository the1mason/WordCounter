using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.WPF.Service
{
    public static class StatisticsService
    {
        public static async void SendStatistics(List<Lib.Word> words)
        {
            using Db.StatisticsContext db = new();
            foreach (Lib.Word word in words)
            {
                if(db.Words.Any(x => x.Value == word.Value))
                {
                    db.Words.First(x => x.Value == word.Value).Count += word.Count;
                }
                else
                {
                    db.Words.Add(new () { Value = word.Value, Count = word.Count });
                }
            }
            db.SaveChanges();
        }

        public static List<Lib.Word> GetStatistics()
        {
            using Db.StatisticsContext db = new();
            List<Db.Word> dbWords = db.Words.ToList();
            List<Lib.Word> words = new();
            foreach (Db.Word word in dbWords)
            {
                words.Add(new() { Value = word.Value, Count = word.Count });
            }
            return words;
        }
    }
}
