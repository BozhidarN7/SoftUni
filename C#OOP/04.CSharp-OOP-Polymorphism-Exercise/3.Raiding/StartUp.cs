using System;
using System.Collections.Generic;

namespace _3.Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while(true)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                
                if (type == nameof(Druid))
                {
                    raidGroup.Add(new Druid(name));
                }
                else if(type == nameof(Paladin))
                {
                    raidGroup.Add(new Paladin(name));
                }
                else if(type == nameof(Rogue))
                {
                    raidGroup.Add(new Rogue(name));
                }
                else if(type == nameof(Warrior))
                {
                    raidGroup.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
                if (raidGroup.Count == n)
                {
                    break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            int totalHeroPower = 0;
            foreach(BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                totalHeroPower += hero.Power;
            }
            if (totalHeroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
