using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.EmojiDetector
{
    class EmojiDetector
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"\d");

            long coolThresholdSum = 1;
            pattern.Matches(input).Cast<Match>().Select(x => int.Parse(x.Value)).ToList().ForEach(x => coolThresholdSum *= x);

            pattern = new Regex(@"(::|\*\*)[A-Z][a-z]{2,}\1");
            MatchCollection matches = pattern.Matches(input);

            List<string> emojis = matches.Select(x =>
            {
                long coolness = x.Value.Substring(2, x.Value.Length - 4).ToCharArray().Select(y => (int)y).Sum();
                if (coolness > coolThresholdSum)
                {
                    return x.Value;
                }
                return "";
            }).Where(x => x != "").ToList();

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join("\n", emojis));

        }
    }
}
