using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }
                    wardrobe[color][cloth]++;
                }
            }

            string[] tokens = Console.ReadLine().Split();
            string neededColor = tokens[0];
            string neededCloth = tokens[1];

            foreach (var pair in wardrobe)
            {
                Console.WriteLine($"{pair.Key} clothes:");
                foreach (var clothes in pair.Value)
                {
                    Console.WriteLine($"* {clothes.Key} - {clothes.Value} {(pair.Key == neededColor && clothes.Key == neededCloth ? "(found!)" : "")}");
                }
            }
        }
    }
}
