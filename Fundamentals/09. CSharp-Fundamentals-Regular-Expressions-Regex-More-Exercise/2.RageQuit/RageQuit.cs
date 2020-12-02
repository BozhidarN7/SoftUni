using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"\d+");
            MatchCollection matches = pattern.Matches(input);
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            StringBuilder result = new StringBuilder();
            int startIndex = 0;
            foreach (Match match in matches)
            {
                int endIndex = match.Index;
                string current = input.Substring(startIndex, endIndex - startIndex).ToUpper();
                for (int i = 0; i < int.Parse(match.Value); i++)
                {
                    result.Append(current);
                }
                startIndex = endIndex + 1;
                if (match.Value.Length == 2)
                {
                    startIndex += 1;
                }
                if (match.Value != "0")
                {
                    CountUniqueSymbols(symbols, current);
                }
            }
            Console.WriteLine($"Unique symbols used: {symbols.Count}");
            Console.WriteLine(result.ToString());
        }

        private static int CountUniqueSymbols(Dictionary<char, int> symbols, string current)
        {
            for (int i = 0; i < current.Length; i++)
            {
                if (!symbols.ContainsKey(current[i]))
                {
                    symbols.Add(current[i], 0);
                }
                symbols[current[i]]++;
            }

            return symbols.Count;
        }
    }
}
