using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.LargestThreeNumbers
{
    class LargestThreeNumbers
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList()
                .ForEach(x => Console.Write(x + " "));
        }
    }
}
