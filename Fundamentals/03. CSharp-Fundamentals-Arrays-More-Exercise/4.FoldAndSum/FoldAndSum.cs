using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _4.FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            int[] leftSums = new int[k];
            int[] rightSums = new int[k];
            for (int i = 0; i < k; i++)
            {
                leftSums[i] = arr[i] + arr[2 * k - i - 1];
                rightSums[i] = arr[arr.Length - 1 - i] + arr[arr.Length - (2 * k - i)];
            }
            Array.Reverse(leftSums);
            Console.Write(string.Join(" ", leftSums));
            Console.Write(" ");
            Console.WriteLine(string.Join(" ", rightSums));
        }
    }
}
