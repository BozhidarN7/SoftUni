using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> claimedItems = new List<int>();

            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();

                if ((firstItem + secondItem) % 2 == 0)
                {
                    claimedItems.Add(firstItem + secondItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
