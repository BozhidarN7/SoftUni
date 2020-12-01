using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))");
            pattern.Matches(input).Cast<Match>().Select(x => x.Value).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
