using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\b([A-Za-z][A-Za-z0-9_]{2,25})\b");
            string input = Console.ReadLine();
            string[] names = pattern.Matches(input).Cast<Match>().Select(x => x.Value).ToArray();

            int maxLength = 0;
            string firstName = "";
            string secondName = "";
            for (int i = 0; i < names.Length - 1; i++)
            {
                if (names[i].Length + names[i + 1].Length > maxLength)
                {
                    maxLength = names[i].Length + names[i + 1].Length;
                    firstName = names[i];
                    secondName = names[i + 1];
                }
            }
            Console.WriteLine(firstName);
            Console.WriteLine(secondName);
        }
    }
}
