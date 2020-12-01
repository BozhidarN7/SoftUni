using System;
using System.Linq;

namespace _8.CondenceArrayToNumber
{
    class CondenceArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = arr.Length;
            for (int i = 0; i < length -1; i++)
            {
                int[] condance = new int[arr.Length - 1];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    condance[j] = arr[j] + arr[j + 1];
                }

                arr = condance;
            }

            foreach (int number in arr)
            {
                Console.WriteLine(number);
            }
        }
    }
}
