using System;
using System.Text.RegularExpressions;

namespace _8.Mines
{
    class Mines
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"<[A-Za-z]{2}>");

            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                int index = match.Index;
                int range = Math.Abs(input[index + 1] - input[index + 2]);

                int toTheLeft = index - range >= 0 ? index - range : 0;
                int toTheRight = index + range + 3 <= input.Length - 1 ? index + range + 3 : input.Length - 1;

                string newPart = new string('_', toTheRight - toTheLeft + 1);
                string replacementPart = input.Substring(toTheLeft, toTheRight - toTheLeft + 1);
                input = input.Replace(replacementPart, newPart);

            }
            Console.WriteLine(input);
        }
    }
}
