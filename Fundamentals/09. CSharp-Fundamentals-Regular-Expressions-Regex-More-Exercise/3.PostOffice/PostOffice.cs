using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _3.PostOffice
{
    class PostOffice
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            Regex pattern = new Regex(@"([#$%*&])[A-Z]+\1");
            Dictionary<char, int> wordsInformation = new Dictionary<char, int>();

            Match match = pattern.Match(input[0]);
            for (int i = 1; i < match.Value.Length - 1; i++)
            {
                wordsInformation.Add(match.Value[i], 0);
            }
            pattern = new Regex(@"([6789]\d):([0]?\d{2})");
            string[] matches = pattern.Matches(input[1]).Cast<Match>().Select(x => x.Value).Distinct().ToArray();

            for (int i = 0; i < matches.Length; i++)
            {
                char letter = (char)int.Parse(matches[i].Substring(0, 2));
                int length = 0;
                if (matches[i][3] == '0')
                {
                    length = matches[i][4] - '0';
                }
                else
                {
                    length = int.Parse(matches[i].Substring(3));
                }

                wordsInformation[letter] = length;
            }

            string[] words = input[2].Split();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordsInformation.ContainsKey(words[i][0]) && wordsInformation[words[i][0]] + 1 == words[i].Length)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }
    }
}
