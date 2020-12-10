using System;
using System.Text.RegularExpressions;

namespace _5.КеyReplacer
{
    class КеyReplacer
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"^([A-Za-z]+)[\||<|\\](.+)[\||<|\\]([A-Za-z]+)");
            Match match = pattern.Match(input);
            string startKey = match.Groups[1].Value;
            string endKey = match.Groups[3].Value;

            string message = Console.ReadLine();
            pattern = new Regex($@"{startKey}(?!{endKey})(.*?){endKey}");
            MatchCollection matches = pattern.Matches(message);
            string result = "";
            foreach(Match item in matches)
            {
                result += item.Groups[1].Value;
            }
            if (result == string.Empty)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
