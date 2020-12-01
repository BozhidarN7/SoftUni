using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"(\+359 2 \d{3} \d{4}\b)|(\+ ?359-2-\d{3}-\d{4}\b)");
            string[] result = pattern.Matches(input).Cast<Match>().Select(x => x.Value).ToList().ToArray();
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
