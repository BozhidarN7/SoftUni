using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _5.SumEvenNumbers
{
    class SumEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = numbers.Where(x => x % 2 == 0).Sum();

            Console.WriteLine(sum);


        }
    }
}
