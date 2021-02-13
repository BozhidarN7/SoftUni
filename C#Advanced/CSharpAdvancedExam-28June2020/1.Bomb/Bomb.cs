using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Bomb
{
    class Bomb
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> bombs = new Dictionary<int, int>()
            {
                {40,0 },
                {60,0 },
                {120,0 }
            };
            Dictionary<int, string> bombTypes = new Dictionary<int, string>()
            {
                {40,"Datura Bombs"},
                {60,"Cherry Bombs"},
                {120,"Smoke Decoy Bombs"}
            };
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            bool filled = false;
            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                int bombEffect = bombEffects.Peek();
                int bombCasing = bombCasings.Pop();

                int sum = bombEffect + bombCasing;

                if (bombs.ContainsKey(sum))
                {
                    bombEffects.Dequeue();
                    bombs[sum]++;
                }
                else
                {
                    bombCasing -= 5;
                    bombCasings.Push(bombCasing);
                }

                if (bombs.Select(x => x.Value).TakeWhile(x => x >= 3).Count() == 3)
                {
                    filled = true;
                    break;
                }
            }
            if (filled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            foreach ((int number, string type) in bombTypes.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{type}: {bombs[number]}");
            }

        }
    }
}
