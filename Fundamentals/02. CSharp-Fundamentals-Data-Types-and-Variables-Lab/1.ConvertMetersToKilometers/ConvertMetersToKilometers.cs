using System;

namespace _1.ConvertMetersToKilometers
{
    class ConvertMetersToKilometers
    {
        static void Main(string[] args)
        {
            decimal metres = decimal.Parse(Console.ReadLine());
            decimal result = metres / 1000;

            Console.WriteLine($"{result:f2}");
        }
    }
}
