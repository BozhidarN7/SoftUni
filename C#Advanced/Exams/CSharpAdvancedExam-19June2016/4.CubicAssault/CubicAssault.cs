using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _4.CubicAssault
{
    class CubicAssault
    {
        private const int MAX = 1000000;
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "Count em all")
            {
                string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string region = tokens[0];
                string meteorType = tokens[1];
                long count = long.Parse(tokens[2]);
                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>()
                    {
                        {"Black",0L },
                        {"Red",0L },
                        {"Green",0L }
                    });
                }
                regions[region][meteorType] += count;

                if (regions[region][meteorType] >= MAX)
                {
                    if (meteorType == "Green")
                    {
                        regions[region]["Red"] += regions[region][meteorType] / MAX;
                        if (regions[region]["Red"] >= MAX)
                        {
                            regions[region]["Black"] += regions[region]["Red"] / MAX;
                            regions[region]["Red"] = regions[region]["Red"] % MAX;
                        }
                    }
                    else if (meteorType == "Red")
                    {
                        regions[region]["Black"] += regions[region]["Red"] / MAX;
                    }
                    regions[region][meteorType] = regions[region][meteorType] % MAX;
                }

                input = Console.ReadLine();
            }

            foreach (var region in regions.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{region.Key}");
                foreach (var pair in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {pair.Key} : {pair.Value}");
                }
            }
        }
    }
}
