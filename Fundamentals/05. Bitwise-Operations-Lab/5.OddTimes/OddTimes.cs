using System;
using System.Linq;

namespace _5.OddTimes
{
    class OddTimes
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result = result ^ arr[i];
            }

            Console.WriteLine(result);
        }
    }
}
