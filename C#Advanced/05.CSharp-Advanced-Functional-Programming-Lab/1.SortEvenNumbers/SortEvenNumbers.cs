using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).OrderBy(x => x).ToList()));
        }
    }
}
