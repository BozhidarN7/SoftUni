using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsOfElement
{
    class SetsOfElement
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = tokens[0];
            int m = tokens[1];

            HashSet<int> setOne = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                setOne.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> setTwo = new HashSet<int>();
            for (int i = 0; i< m; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            setOne.IntersectWith(setTwo);
            Console.WriteLine(string.Join(" ",setOne));
        }
    }
}
