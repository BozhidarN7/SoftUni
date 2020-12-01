using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Snowwhite
{
    class Snowwhite
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfs = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string color = tokens[1];
                int physics = int.Parse(tokens[2]);

                string id = name + ":" + color;
                if (!dwarfs.ContainsKey(id))
                {
                    dwarfs.Add(id, physics);
                }
                else
                {
                    dwarfs[id] = Math.Max(dwarfs[id], physics);
                }
                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value).ThenByDescending(x => dwarfs.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {

                Console.WriteLine($"({dwarf.Key.Split(':')[1]}) {dwarf.Key.Split(':')[0]} <-> {dwarf.Value}");

            }
        }
    }
}
