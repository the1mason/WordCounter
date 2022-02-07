using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter.Lib.Services
{
    public class HtmlParser : IParser
    {
        public List<string> Parse(string input)
        {
            input = CutWholeHtmlTag(input, "head");
            input = CutWholeHtmlTag(input, "noscript");
            input = CutWholeHtmlTag(input, "script");
            input = CutWholeHtmlTag(input, "image");
            input = CutWholeHtmlTag(input, "iframe");
            input = CutHtmlComments(input);
            input = CutHtmlTagNamesOnly(input);
            var splitChars = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':',
                '[', ']', '(', ')', '\n', '\r', '\t', '\\', '/', '{', '}' };
            List<string> result = new();
            foreach (string s in input.ToUpper().Split(splitChars).ToList())
            {
                if(s.Any(x => char.IsLetter(x)))
                {
                    result.Add(s);
                }
            }
            return result;
        }

        private string CutWholeHtmlTag(string content, string tag)
        {
            return Regex.Replace(content, @$"<{tag}[\W\w\S\s]*?>[\W\w\S\s]*?</{tag}>", string.Empty);
        }
        private string CutHtmlComments(string content)
        {
            return Regex.Replace(content, @"<!--[\W\w\S\s]*?-->", string.Empty);
        }

        private string CutHtmlTagNamesOnly(string content)
        {
            return Regex.Replace(content, @"<[\W\w\S\s]*?>", string.Empty);
        }

        public static string CutSymbolTags(string htmlContent)
        {
            string[] symbols = new string[]
            {
                "&nbsp;", "&#160;",
                "&copy;", "&#169;",
                "&reg;", "&#174;",
                "&trade;", "&#8482;",
                "&quot;", "&#34;",
                "&ndash;", "&#8211;",
                "&mdash;", "&#8212;",
                "&laquo;", "&#171;",
                "&raquo;", "&#187;",
            };

            string symbolsString = string.Empty;
            foreach (string symbol in symbols)
            {
                symbolsString += $"{symbol}|";
            }
            symbolsString = symbolsString.Remove(symbolsString.Length - 1);

            return Regex.Replace(htmlContent, @$"{symbolsString}", string.Empty);
        }
    }
}
