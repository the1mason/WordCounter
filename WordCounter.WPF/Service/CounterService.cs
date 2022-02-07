using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.WPF.Service
{
    public static class CounterService
    {
        public static List<Lib.Word> GetHtmlCount(string source)
        {
            Lib.Counter counter = new();
            if(source.Length < 5)
                return counter.Count(source, Lib.ICounter.Method.HTML, Lib.ICounter.SourceType.Local);
            if (!source.Substring(0, 4).Contains("http"))
                return counter.Count(source, Lib.ICounter.Method.HTML, Lib.ICounter.SourceType.Local);
            else
                return counter.Count(source, Lib.ICounter.Method.HTML, Lib.ICounter.SourceType.Net);
        }
    }
}
