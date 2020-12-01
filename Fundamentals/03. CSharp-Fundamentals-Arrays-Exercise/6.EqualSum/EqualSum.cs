using System;
using System.Linq;

namespace _6.EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool hasEqualSum = false;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    hasEqualSum = true;
                    break;
                }
            }

            if (!hasEqualSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
