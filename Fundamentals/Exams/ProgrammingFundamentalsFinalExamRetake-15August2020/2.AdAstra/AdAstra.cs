using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.AdAstra
{
    class AdAstra
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(#|\|)(?<itemName>[A-Za-z\s]+)\1(?<expirationDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>\d{1,})\1");
            string input = Console.ReadLine();
            MatchCollection matches = pattern.Matches(input);
            int totalCalories = matches.Select(x => x.Groups["calories"].Value).Select(int.Parse).Sum();
            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            foreach(Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["itemName"].Value}, Best before: {match.Groups["expirationDate"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
