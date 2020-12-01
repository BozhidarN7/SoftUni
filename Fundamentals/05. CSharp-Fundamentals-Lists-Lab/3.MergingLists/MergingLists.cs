using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MergingLists
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<int> arr1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> arr2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();

            int i;
            for (i = 0; i < Math.Min(arr1.Count, arr2.Count); i++)
            {
                result.Add(arr1[i]);
                result.Add(arr2[i]);
            }

            for (; i < Math.Max(arr1.Count, arr2.Count); i++)
            {
                result.Add(arr1.Count < arr2.Count ? arr2[i] : arr1[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
