using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < n;i++)
            {
                string[] input = Console.ReadLine().Split();
                foreach (string element in input)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
