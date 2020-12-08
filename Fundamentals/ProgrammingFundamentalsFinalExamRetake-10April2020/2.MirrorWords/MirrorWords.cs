using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MirrorWords
{
    class MirrorWords
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(@|#)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1");
            string input = Console.ReadLine();
            MatchCollection matches = pattern.Matches(input);
            List<Match> mirrorWords = new List<Match>();
            foreach (Match match in matches)
            {
                string first = match.Groups["first"].Value;
                string second = match.Groups["second"].Value;

                if (first == new string(second.Reverse().ToArray()))
                {
                    mirrorWords.Add(match);
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                }
                for (int i = 0; i < mirrorWords.Count; i++)
                {
                    if (i == mirrorWords.Count - 1)
                    {
                        Console.WriteLine($"{mirrorWords[i].Groups["first"].Value} <=> {mirrorWords[i].Groups["second"].Value}");
                    }
                    else
                    {
                        Console.Write($"{mirrorWords[i].Groups["first"].Value} <=> {mirrorWords[i].Groups["second"].Value}, ");
                    }
                }
            }
        }
    }
}
