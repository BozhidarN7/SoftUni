using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<int, int> products = new Dictionary<int, int>()
            {
                {25,0},
                {50,0 },
                {75,0},
                {100,0}
            };
            Dictionary<int, string> foodNames = new Dictionary<int, string>()
            {
                {25,"Bread"},
                {50,"Cake" },
                {75,"Pastry"},
                {100,"Fruit Pie"}
            };
            int currentValue = 0;
            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient + currentValue;
                if (products.ContainsKey(sum))
                {
                    products[sum] += 1;
                }
                else
                {
                    ingredient += 3;
                    ingredients.Push(ingredient);
                }
            }
            bool success = products.Values.All(x => x >= 1);
            if (success)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            Console.WriteLine($"Liquids left: {(liquids.Count != 0 ? string.Join(", ", liquids) : "none")}");
            Console.WriteLine($"Ingredients left: {(ingredients.Count != 0 ? string.Join(", ", ingredients) : "none")}");
            foreach ((int value, string food) in foodNames.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{food}: {products[value]}");
            }
        }
    }
}
