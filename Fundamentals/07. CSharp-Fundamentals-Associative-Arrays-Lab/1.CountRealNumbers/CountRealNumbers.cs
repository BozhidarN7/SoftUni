using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int, int> dic = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dic.ContainsKey(arr[i]))
                {
                    dic.Add(arr[i], 0);
                }
                dic[arr[i]]++;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
