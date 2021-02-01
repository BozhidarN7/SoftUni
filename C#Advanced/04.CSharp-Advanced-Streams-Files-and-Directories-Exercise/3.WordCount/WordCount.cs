using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsOcc = new Dictionary<string, int>();
            string[] lines = File.ReadAllLines(@"../../../../words.txt");
            string text = File.ReadAllText(@"../../../../text.txt").ToLower();
            foreach(string line in lines)
            {
                int occoccurrences = Regex.Matches(text, $@"\b({line})\b").Count;
                if (!wordsOcc.ContainsKey(line))
                {
                    wordsOcc.Add(line, 0);
                }
                wordsOcc[line] += occoccurrences;
            }
            string actualResult = string.Empty;
            foreach((string word,int occ) in wordsOcc.OrderByDescending(x => x.Value))
            {
                actualResult += $"{word} - {occ}{Environment.NewLine}";
            }
            //List<string> actualResult = wordsOcc.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();
            //File.WriteAllText(@"../../../../actualResult.txt", string.Join(Environment.NewLine,actualResult));

            string expectedResult = File.ReadAllText(@"../../../../expectedResult.txt");

            if (actualResult == expectedResult)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
