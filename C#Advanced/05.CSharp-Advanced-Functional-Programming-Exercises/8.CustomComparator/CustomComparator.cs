using System;
using System.Linq;

namespace _8.CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr, (a, b) =>
            {
                if (a % 2 == 0 && b % 2 !=0) return -1;
                if (b % 2 == 0 && a % 2 != 0) return 1;

                return a.CompareTo(b);
            });
            Console.WriteLine(string.Join(" ", arr));

        }
    }
}
