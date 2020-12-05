using System;
using System.Text.RegularExpressions;

namespace _2.ExtractSentencesByKeyword
{
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();

            Regex pattern = new Regex($@"\b[^?.!]*\b{keyWord}\b[^?.!]*");
            MatchCollection matches = pattern.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
