using System;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0).ToArray()));
        }
    }
}
