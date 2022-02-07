using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Db
{
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Source { get; set; }
        public string Count { get; set; }
    }
}
