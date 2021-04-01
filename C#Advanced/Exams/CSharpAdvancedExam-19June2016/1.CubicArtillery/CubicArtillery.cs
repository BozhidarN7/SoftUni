using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CubicArtillery
{
    class CubicArtillery
    {
        static void Main(string[] args)
        {
            Queue<char> bunkers = new Queue<char>();
            Dictionary<char, Queue<int>> weapons = new Dictionary<char, Queue<int>>();
            int weaponCapacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int currSum = 0;
            List<int> weaponsForTheNextBunker = new List<int>();
            while (input != "Bunker Revision")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; i++)
                {
                    int currWeapon = 0;
                    if (char.IsLetter(tokens[i][0]))
                    {
                        bunkers.Enqueue(tokens[i][0]);
                        weapons.Add(tokens[i][0], new Queue<int>());
                        continue;
                    }
                    else
                    {
                        currWeapon = int.Parse(tokens[i]);
                    }

                    if (currWeapon > weaponCapacity)
                    {
                        continue;
                    }

                    char currBunker = bunkers.Peek();
                    if (currSum + currWeapon <= weaponCapacity)
                    {
                        currSum += currWeapon;
                        weapons[currBunker].Enqueue(currWeapon);
                    }
                    else if (currSum + currWeapon > weaponCapacity && bunkers.Count == 1)
                    {
                        while (currSum + currWeapon > weaponCapacity)
                        {
                            currSum -= weapons[currBunker].Dequeue();
                        }
                        currSum += currWeapon;
                        weapons[currBunker].Enqueue(currWeapon);
                    }
                    else if (currSum + currWeapon > weaponCapacity && bunkers.Count > 1)
                    {
                        weaponsForTheNextBunker.Add(currWeapon);
                    }
                }

                input = Console.ReadLine();
            }
            while (bunkers.Count > 1)
            {
                char currBunker = bunkers.Peek();
                int sum = weapons[currBunker].Sum();
                for (int i = 0; i < weaponsForTheNextBunker.Count; i++)
                {
                    if (sum + weaponsForTheNextBunker[i] <= weaponCapacity)
                    {
                        weapons[currBunker].Enqueue(weaponsForTheNextBunker[i]);
                        sum += weaponsForTheNextBunker[i];
                        weaponsForTheNextBunker.RemoveAt(i);
                        i--;
                    }
                }
                if (weapons[currBunker].Count == 0)
                {
                    Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                }
                else
                {
                    Print(weapons, currBunker);
                    weapons.Remove(bunkers.Dequeue());
                }
            }
        }

        private static void Print(Dictionary<char, Queue<int>> weapons, char currBunker)
        {
            Console.WriteLine($"{currBunker} -> {string.Join(", ",weapons[currBunker])}");
        }
    }
}
