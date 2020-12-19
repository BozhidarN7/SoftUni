using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.DestinationMapper
{
    class DestinationMapper
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1");
            string input = Console.ReadLine();
            List<string> destinations = pattern.Matches(input).Select(x => x.Groups["destination"].Value).ToList();
            int travelPoints = destinations.Sum(x => x.Length);

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
