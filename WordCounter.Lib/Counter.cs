using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Lib.Services;
using WordCounter.Lib.Exceptions;

namespace WordCounter.Lib
{
    public class Counter : ICounter
    {
        /// <summary>
        /// Counts amount of UNIQUE words from source stream
        /// </summary>
        /// <param name="source">Web URL or local URI</param>
        /// <param name="method">Parsing method</param>
        /// <param name="sourceType">Type of source to fetch</param>
        /// <returns>List of unique words and repeat count</returns>
        /// <exception cref="CounterException">Library exception</exception>
        public List<Word> Count(string source, ICounter.Method method, ICounter.SourceType sourceType)
        {
            string rawFile = "";

            if (sourceType == ICounter.SourceType.Local)
                rawFile = FetchService.FetchFromFile(source);

            else if (sourceType == ICounter.SourceType.Net)
                rawFile = FetchService.FetchFromUrl(source);

            else
                throw new CounterException("Unknown source type!");

            if (method == ICounter.Method.HTML)
            {
                HtmlParser parser = new();
                return GetWords(parser.Parse(rawFile));
            }
            else
            {
                throw new CounterException("Unknown parse method!");
            }
        }

        private List<Word> GetWords(List<string> parsedWords)
        {
            List<Word> words = new();
            foreach (string parsedWord in parsedWords)
            {
                if(words.Any(x => x.Value == parsedWord))
                {
                    words.First(x => x.Value == parsedWord).Count++;
                }
                else
                {
                    words.Add(new() { Count = 1, Value = parsedWord});
                }
            }
            return words;
        }
    }
}
