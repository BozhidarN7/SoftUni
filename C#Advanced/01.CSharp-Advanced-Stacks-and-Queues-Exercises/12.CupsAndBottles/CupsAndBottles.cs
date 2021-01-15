using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int totalWasted = 0;
            while (cups.Count != 0 & bottles.Count != 0)
            {
                int currentCup = cups.Dequeue();
                int currentBottle = bottles.Pop();

                if (currentCup <= currentBottle)
                {
                    totalWasted += Math.Abs(currentBottle - currentCup);
                }
                else
                {
                    currentCup -= currentBottle;
                    while (bottles.Count != 0 && currentCup > 0)
                    {
                        currentBottle = bottles.Pop();
                        if (currentBottle >= currentCup)
                        {
                            totalWasted += Math.Abs(currentBottle - currentCup);
                        }
                        currentCup -= currentBottle;

                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {(bottles.Count != 0 ? string.Join(" ", bottles) : "")}");
            }
            else
            {
                Console.WriteLine($"Cups: {(cups.Count != 0 ? string.Join(" ", cups) : "")}");
            }
            Console.WriteLine($"Wasted litters of water: {totalWasted}");
        }
    }
}
