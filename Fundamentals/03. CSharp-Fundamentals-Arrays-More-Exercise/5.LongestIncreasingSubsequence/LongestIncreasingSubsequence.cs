using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int>[] lis = new List<int>[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                lis[i] = new List<int>();
            }

            lis[0].Add(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((arr[i] > arr[j]) && (lis[i].Count < lis[j].Count + 1))
                    {
                        lis[i] = lis[j];
                    }
                }

               lis[i].Add(arr[i]);
            }
            List<int> max = lis[0];

            foreach (var item in lis)
            {
                if (item.Count > max.Count)
                {
                    max = item;
                }
            }

            Console.WriteLine(string.Join(" ", max));
        }
    }
}
