using System;
using System.Linq;

namespace _4.AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(x => x + x * 0.2).ToList()
             .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
