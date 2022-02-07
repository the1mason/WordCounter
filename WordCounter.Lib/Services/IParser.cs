using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Lib.Services
{
    public interface IParser
    {
        public List<string> Parse(string input);
    }
}
