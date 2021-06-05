using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Knapsack
{
    class Knapsack
    {
        static void Main(string[] args)
        {
            int bagCapacity = int.Parse(Console.ReadLine());

            List<Item> items = new List<Item>();

            var input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split(' ');
                items.Add(new Item(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
                input = Console.ReadLine();
            }

            int[,] prices = new int[items.Count + 1, bagCapacity + 1];
            bool[,] isItemTaken = new bool[items.Count + 1, bagCapacity + 1];

            PutIntoTheBag(items, prices, isItemTaken, bagCapacity);
            List<Item> result = RestoreItems(items, isItemTaken, bagCapacity).ToList();

            Console.WriteLine("Total Weight: {0}", result.Sum(x => x.Weight));
            Console.WriteLine("Total Value: {0}", result.Sum(x => x.Value));

            result.Reverse();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static List<Item> RestoreItems(List<Item> items, bool[,] isItemTaken, int bagCapacity)
        {
            int currentCapacity = bagCapacity;
            List<Item> result = new List<Item>();

            for (int i = items.Count; i > 0; i--)
            {
                if (!isItemTaken[i, currentCapacity])
                {
                    continue;
                }

                Item item = items[i - 1];
                result.Add(item);
                currentCapacity -= item.Weight;
            }

            return result;
        }

        private static void PutIntoTheBag(List<Item> items, int[,] prices, bool[,] isItemTake, int bagCapacity)
        {
            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                for (int currentCapacity = 1; currentCapacity <= bagCapacity; currentCapacity++)
                {
                    if (items[itemIndex].Weight > currentCapacity)
                    {
                        continue;
                    }

                    int excluding = prices[itemIndex, currentCapacity];
                    int including = items[itemIndex].Value + prices[itemIndex, currentCapacity - items[itemIndex].Weight];

                    if (including > excluding)
                    {
                        prices[itemIndex + 1, currentCapacity] = including;
                        isItemTake[itemIndex + 1, currentCapacity] = true;
                    }
                    else
                    {
                        prices[itemIndex + 1, currentCapacity] = prices[itemIndex, currentCapacity];
                    }
                }
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }
    }
}
