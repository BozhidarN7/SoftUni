using System;
using System.Text.RegularExpressions;

namespace _1.Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\[[A-Z&a-z]+<([0-9]+)REGEH([0-9]+)>[A-Z&a-z]+\]");
            MatchCollection matches = regex.Matches(input);
            string result = "";
            int index = 0;
            foreach (Match match in matches)
            {
                int current = int.Parse(match.Groups[1].Value);
                index += current;
                index %= input.Length;
                result += input[index];

                current = int.Parse(match.Groups[2].Value);
                index += current;
                index %= input.Length;
                result += input[index];
            }

            Console.WriteLine(result);
        }
    }
}
