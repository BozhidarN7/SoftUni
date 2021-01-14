using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(orders.Max());
            while (orders.Count != 0)
            {
                if (orders.Peek() <= quantity)
                {
                    quantity -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
