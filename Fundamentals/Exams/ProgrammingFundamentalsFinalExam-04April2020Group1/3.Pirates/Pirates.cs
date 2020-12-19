using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Pirates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cities = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "Sail")
            {
                string[] tokens = input.Split("||");
                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new Dictionary<string, int>()
                    {
                        {"population", 0 },
                        {"gold",0 }
                    });
                }
                cities[city]["population"] += population;
                cities[city]["gold"] += gold;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split("=>");
                string city = tokens[1];
                int population = int.Parse(tokens[2]);

                if (tokens[0] == "Plunder")
                {
                    int gold = int.Parse(tokens[3]);
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");
                    cities[city]["population"] -= population;
                    cities[city]["gold"] -= gold;

                    if (cities[city]["population"] <= 0 || cities[city]["gold"] <= 0)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else
                {
                    int gold = int.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[city]["gold"] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city]["gold"]} gold.");
                    }
                }

                input = Console.ReadLine();
            }
            if (cities.Count != 0)
            {
                Console.WriteLine("Ahoy, Captain! There are {0} wealthy settlements to go to:", cities.Count);

                foreach (var city in cities.OrderByDescending(x => x.Value["gold"]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value["population"]} citizens, Gold: {city.Value["gold"]} kg");
                }
            }
        }
    }
}
