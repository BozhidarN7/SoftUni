using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PlantDiscovery
{
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                if (!plants.ContainsKey(tokens[0]))
                {
                    plants.Add(tokens[0], new Plant());
                }
                plants[tokens[0]].Rarity = double.Parse(tokens[1]);
            }

            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] operations = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string[] tokens = operations[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (operations[0] == "Rate")
                {
                    if (plants.ContainsKey(tokens[0]))
                    {
                        plants[tokens[0]].Raitings.Add(double.Parse(tokens[1]));
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operations[0] == "Update")
                {
                    if (plants.ContainsKey(tokens[0]))
                    {
                        plants[tokens[0]].Rarity = double.Parse(tokens[1]);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operations[0] == "Reset")
                {
                    if (plants.ContainsKey(tokens[0]))
                    {
                        plants[tokens[0]].Raitings = new List<double>();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                command = Console.ReadLine();
            }
            plants = plants.Select(x =>
             {
                 if (x.Value.Raitings.Count == 0)
                 {
                     x.Value.Raitings.Add(0);
                 }
                 return x;
             }).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Raitings.Average()))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.Raitings.Average():f2}");
            }
        }
    }

    public class Plant
    {
        public double Rarity { get; set; }
        public List<double> Raitings { get; set; }
        public Plant()
        {
            Raitings = new List<double>();
        }
    }
}
