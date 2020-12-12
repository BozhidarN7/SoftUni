using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5.OnlyLetters
{
    class OnlyLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"[0-9]+");

            int removedDigits = 0;
            List<char> result = input.ToList();
            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                int index = match.Index;
                int length = match.Length;

                if (index + length >= input.Length)
                {
                    break;
                }

                char letter = input[index + length];
                result.RemoveRange(index -removedDigits, length);
                result.Insert(index -removedDigits, letter);
                removedDigits += length - 1;
            }
            Console.WriteLine(string.Join("",result));
        }
    }
}
