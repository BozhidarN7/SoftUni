using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisable = number => number % n == 0;
            Func<int[], int[]> reverseArray = arr =>
            {
                List<int> reversedArr = new List<int>();
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (!isDivisable(arr[i]))
                    {
                        reversedArr.Add(arr[i]);
                    }
                }
                return reversedArr.ToArray();
            };
            Console.WriteLine(string.Join(" ", reverseArray(arr)));
        }
    }
}
