using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HeroesOfCodeAndLogicVII
{
    class HeroesOfCodeAndLogicVII
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> heros = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string hero = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                if (!heros.ContainsKey(hero))
                {
                    heros.Add(hero, new Dictionary<string, int>()
                    {
                        {"hp",0 },
                        {"mp",0 }
                    });
                }
                heros[hero]["hp"] += hp;
                heros[hero]["mp"] += mp;

                HasMoreHP(heros, hero);
                HasMoreMP(heros, hero);

            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens[0] == "CastSpell")
                {
                    if (heros[tokens[1]]["mp"] >= int.Parse(tokens[2]))
                    {
                        heros[tokens[1]]["mp"] -= int.Parse(tokens[2]);
                        Console.WriteLine($"{tokens[1]} has successfully cast {tokens[3]} and now has {heros[tokens[1]]["mp"]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[1]} does not have enough MP to cast {tokens[3]}!");
                    }
                }
                else if (tokens[0] == "TakeDamage")
                {
                    heros[tokens[1]]["hp"] -= int.Parse(tokens[2]);
                    if (heros[tokens[1]]["hp"] > 0)
                    {
                        Console.WriteLine($"{tokens[1]} was hit for {tokens[2]} HP by {tokens[3]} and now has {heros[tokens[1]]["hp"]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[1]} has been killed by {tokens[3]}!");
                        heros.Remove(tokens[1]);
                    }
                }
                else if (tokens[0] == "Recharge")
                {
                    int oldMP = heros[tokens[1]]["mp"];
                    heros[tokens[1]]["mp"] += int.Parse(tokens[2]);
                    HasMoreMP(heros, tokens[1]);
                    Console.WriteLine($"{tokens[1]} recharged for {heros[tokens[1]]["mp"] - oldMP} MP!");

                }
                else
                {
                    int oldHP = heros[tokens[1]]["hp"];
                    heros[tokens[1]]["hp"] += int.Parse(tokens[2]);
                    HasMoreHP(heros, tokens[1]);
                    Console.WriteLine($"{tokens[1]} healed for {heros[tokens[1]]["hp"] - oldHP} HP!");
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heros.OrderByDescending(x => x.Value["hp"]).ThenBy(x=>x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value["hp"]}");
                Console.WriteLine($"  MP: {hero.Value["mp"]}");
            }
        }

        private static void HasMoreMP(Dictionary<string, Dictionary<string, int>> heros, string hero)
        {
            if (heros[hero]["mp"] > 200)
            {
                heros[hero]["mp"] = 200;

            }
        }
        private static void HasMoreHP(Dictionary<string, Dictionary<string, int>> heros, string hero)
        {
            if (heros[hero]["hp"] > 100)
            {
                heros[hero]["hp"] = 100;
            }
        }
    }
}
