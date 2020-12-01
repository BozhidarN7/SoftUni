using System;
using System.Numerics;

namespace _3.ExactSumOfRealNumbers
{
    class ExactSumOfRealNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int  i = 0; i < n; i++)
            {
                decimal current = decimal.Parse(Console.ReadLine());
                sum += current;
            }

            Console.WriteLine(sum);

        }
    }
}
