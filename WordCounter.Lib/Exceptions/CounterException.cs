using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Lib.Exceptions
{
    public class CounterException : Exception
    {
        public CounterException()
        {

        }
        public CounterException(string message) : base(message)
        {

        }

        public CounterException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
