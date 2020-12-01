using System;
using System.Text.RegularExpressions;

namespace _1.MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            MatchCollection matches = pattern.Matches(input);
            foreach (var match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}
