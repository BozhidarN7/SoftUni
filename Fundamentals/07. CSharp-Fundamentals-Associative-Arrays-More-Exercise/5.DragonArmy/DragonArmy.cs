using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string type = tokens[0];
                string name = tokens[1];
                int damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                int health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                int armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                }
                dragons[type].Add(new Dragon(type, name, damage, health, armor));

                if (dragons.ContainsKey(type) && dragons[type].Find(x => x.Name == name).Name == name)
                {
                    List<Dragon> dragonSame = dragons[type].FindAll(x => x.Name == name).ToList();
                    if (dragonSame.Count > 1)
                    {
                        dragons[type].Remove(dragonSame[1]);
                        Dragon dragon = dragonSame[0];
                        int index = dragons[type].IndexOf(dragon);
                        dragon.Damage = damage;
                        dragon.Health = health;
                        dragon.Armor = armor;
                        dragons[type][index] = dragon;
                    }
                }

            }

            foreach (var item in dragons)
            {
                double averageDamage = item.Value.Average(x => x.Damage);
                double averageHealth = item.Value.Average(x => x.Health);
                double averageArmor = item.Value.Average(x => x.Armor);
                Console.WriteLine($"{item.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var dragon in item.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }

    public class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string type, string name, int damage, int health, int armor)
        {
            Type = type;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
    }
}
