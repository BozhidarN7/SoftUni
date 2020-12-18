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

            string result = "";
            MatchCollection matches = pattern.Matches(input);
            foreach (Match match in matches)
            {
                int index = match.Index;
                int range = Math.Abs(input[index] - input[index + 1]);

                int toTheLeft = index - range >= 0 ? index - range : 0;
                int toTheRight = index + range + 3 <= input.Length - 1 ? index + range + 3 : input.Length - 1;

                result += input.Substring(0, toTheLeft);
                result += new string('_', toTheRight - toTheLeft);
                result += input.Substring(index + 4 + range);

            }
            Console.WriteLine(result);
        }
    }
}
