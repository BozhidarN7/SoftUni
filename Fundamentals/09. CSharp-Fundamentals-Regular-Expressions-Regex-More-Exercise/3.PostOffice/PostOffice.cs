using System;
using System.Text.RegularExpressions;

namespace _3.PostOffice
{
    class PostOffice
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];
            string[] words = thirdPart.Split();

            Regex pattern = new Regex(@"([#$%*&])(?<letters>[A-Z]+)\1");
            string firstLetters = pattern.Match(firstPart).Groups["letters"].Value;

            for (int i = 0; i < firstLetters.Length; i++)
            {
                char current = firstLetters[i];
                int ASCIIcode = current;

                string secondPattern = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
                Match match = Regex.Match(secondPart, secondPattern);

                int length = int.Parse(match.Groups["length"].Value);

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j][0] == current && words[j].Length == length + 1)
                    {
                        Console.WriteLine(words[j]);
                    }
                }
            }
        }
    }
}
