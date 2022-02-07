using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.WPF.Service
{
    public static class ConvertService
    {
        public static List<Lib.Word> DbWordsToModel(List<Db.Word> dbWords)
        {
            List<Lib.Word> words = new();
            dbWords.ForEach(dw => words.Add(new() { Count = dw.Count, Source = dw.Source, Value = dw.Value }));
            return words;
        }
    }
}
