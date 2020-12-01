using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.MixedUpLists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mixed = new List<int>();

            if (list1.Count > list2.Count)
            {
                Mix(list1, list2, true);
            }
            else
            {
                Mix(list1, list2, false);
            }
        }

        private static void Mix(List<int> first, List<int> second, bool bigger)
        {
            List<int> mixed = new List<int>();

            for (int i = 0; i < Math.Min(second.Count,first.Count); i++)
            {
                mixed.Add(first[i]);
                mixed.Add(second[second.Count - 1 - i]);
            }

            int min = 0;
            int max = 0;

            if (bigger)
            {
                min = first[first.Count - 2];
                max = first[first.Count - 1];
            }
            else
            {
                min = second[0];
                max = second[1];
            }

            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            Console.WriteLine(string.Join(" ", mixed.Where(x => x > min && x < max).OrderBy(x => x).ToList()));
        }
    }
}
