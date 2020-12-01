using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.StarEnigma
{
    class StarEnigma
    {
        private static char[] letters = { 's', 't', 'a', 'r' };
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>[AD]+)![^@\-!:>]*->(?<soldiers>\w+)");
            Dictionary<char, List<string>> planets = new Dictionary<char, List<string>>();
            planets.Add('A', new List<string>());
            planets.Add('D', new List<string>());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                int count = message.Where(x => letters.Contains(Char.ToLower(x))).Count();
                string decrypted = "";
                for (int j = 0; j < message.Length; j++)
                {
                    decrypted += (char)(message[j] - count);
                }
                Match match = pattern.Match(decrypted);
                if (!match.Success)
                {
                    continue;
                }
                planets[match.Groups["attackType"].Value.ToCharArray()[0]].Add(match.Groups["planet"].Value);
            }

            foreach (var item in planets)
            {
                if (item.Key == 'A')
                {
                    Console.WriteLine($"Attacked planets: {item.Value.Count}");
                }
                else
                {
                    Console.WriteLine($"Destroyed planets: {item.Value.Count}");
                }
                foreach (var planet in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
