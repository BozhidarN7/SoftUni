using System;
using System.Text.RegularExpressions;

namespace _7.Hideout
{
    class Hideout
    {
        static void Main(string[] args)
        {
            string map = Console.ReadLine();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string character = Regex.Escape(tokens[0]);
                int count = int.Parse(tokens[1]);

                string pattern = $@"[{character}]+";

                foreach (Match match in Regex.Matches(map, pattern))
                {
                    if (match.Length >= count)
                    {
                        Console.WriteLine($"Hideout found at index {match.Index} and it is with size {match.Length}!");
                        return;
                    }
                }
            }
        }
    }
}
