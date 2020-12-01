using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Demon> demons = new List<Demon>();
            Regex healthPattern = new Regex(@"[^\d\.+\-*/]");
            Regex damagePattern = new Regex(@"[+-]?\d+(\.\d+)?");
            for (int i = 0; i < input.Length; i++)
            {
                int health = healthPattern.Matches(input[i]).Cast<Match>().Select(x => char.Parse(x.Value)).Select(x => (int)x).Sum();
                double damage = ExtractDamage(input[i], damagePattern);

                demons.Add(new Demon(input[i], health, damage));
            }
            foreach (var demon in demons.OrderBy(x =>x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }

        private static double ExtractDamage(string name, Regex damagePattern)
        {
            MatchCollection matches = damagePattern.Matches(name);
            double damage = matches.Cast<Match>().Select(x=> double.Parse(x.Value)).Sum();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '*')
                {
                    damage *= 2;
                }
                if (name[i] == '/')
                {
                    damage /= 2;
                }
            }
            return damage;
        }
    }

    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
