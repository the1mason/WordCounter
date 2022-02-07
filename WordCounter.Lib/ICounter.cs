using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Lib
{
    public interface ICounter
    {
        public List<Word> Count(string source, Method method, SourceType sourceType);


        public enum Method
        {
            HTML
        }
        public enum SourceType
        {
            Local,
            Net
        }
    }
}
