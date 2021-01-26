using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
