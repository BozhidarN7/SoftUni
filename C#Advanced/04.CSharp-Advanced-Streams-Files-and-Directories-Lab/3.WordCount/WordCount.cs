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
            string text = File.ReadAllText(@"../../../../Resources/03.WordCount/text.txt").ToLower();
            using (StreamReader reader = new StreamReader(@"../../../../Resources/03.WordCount/words.txt"))
            {
                string[] words = reader.ReadLine().Split();
                foreach (string word in words)
                {
                    MatchCollection matches = Regex.Matches(text, @$"\b({word})\b");
                    int count = matches.Count;
                    if (!wordsOcc.ContainsKey(word))
                    {
                        wordsOcc.Add(word, 0);
                    }
                    wordsOcc[word] = count;

                }
            }
            using (StreamWriter writer = new StreamWriter(@"../../../../Resources/03.WordCount/output.txt"))
            {
                foreach (var pair in wordsOcc.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }

        }
    }
}
