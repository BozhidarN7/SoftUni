using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> forceSides = new Dictionary<string, HashSet<string>>();
            HashSet<string> users = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    if (!forceSides.ContainsKey(tokens[0]))
                    {
                        forceSides.Add(tokens[0], new HashSet<string>());
                    }
                    if (!users.Contains(tokens[1]))
                    {
                        forceSides[tokens[0]].Add(tokens[1]);
                        users.Add(tokens[1]);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    if (users.Contains(tokens[0]))
                    {
                        foreach (var item in forceSides)
                        {
                            if (item.Value.Contains(tokens[0]))
                            {
                                item.Value.Remove(tokens[0]);
                            }
                        }
                    }
                    if (!forceSides.ContainsKey(tokens[1]))
                    {
                        forceSides.Add(tokens[1], new HashSet<string>());
                    }
                    forceSides[tokens[1]].Add(tokens[0]);
                    Console.WriteLine($"{tokens[0]} joins the {tokens[1]} side!");
                }
                input = Console.ReadLine();
            }

            foreach (var forceSide in forceSides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");
                foreach (var user in forceSide.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
