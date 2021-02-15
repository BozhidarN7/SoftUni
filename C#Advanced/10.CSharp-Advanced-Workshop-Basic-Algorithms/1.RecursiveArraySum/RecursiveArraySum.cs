using System;
using System.Linq;

namespace _1.RecursiveArraySum
{
    class RecursiveArraySum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(CalculateSum(numbers, numbers.Length - 1));
        }

        private static int CalculateSum(int[] numbers, int index)
        {
            if (index == 0)
            {
                return numbers[index];
            }
            return numbers[index] + CalculateSum(numbers,index - 1);
        }
    }
}
