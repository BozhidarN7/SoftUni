using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> battles = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            while (command != "Results")
            {
                string[] tokens = command.Split(':');
                if (tokens[0] == "Add")
                {
                    string name = tokens[1];
                    int health = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);
                    if (!battles.ContainsKey(name))
                    {
                        battles.Add(name, new Dictionary<string, int>
                        {
                            {"health", 0 },
                            {"energy", energy }
                        });
                    }
                    battles[name]["health"] += health;
                }
                else if (tokens[0] == "Attack")
                {
                    string attacker = tokens[1];
                    string defender = tokens[2];
                    int damage = int.Parse(tokens[3]);
                    if (battles.ContainsKey(attacker) && battles.ContainsKey(defender))
                    {
                        battles[defender]["health"] -= damage;
                        if (battles[defender]["health"] <= 0)
                        {
                            battles.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }

                        battles[attacker]["energy"] -= 1;
                        if (battles[attacker]["energy"] <= 0)
                        {
                            battles.Remove(attacker);
                            Console.WriteLine($"{attacker} was disqualified!");
                        }
                    }
                }
                else
                {
                    if (tokens[1] == "All")
                    {
                        battles.Clear();
                    }
                    else
                    {
                        battles.Remove(tokens[1]);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"People count: {battles.Count}");
            foreach (var battle in battles.OrderByDescending(x => x.Value["health"]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{battle.Key} - {battle.Value["health"]} - {battle.Value["energy"]}");
            }
        }
    }
}
