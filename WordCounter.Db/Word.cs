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
        [Key]
        public string Value { get; set; }
        public int Count { get; set; }
    }
}
