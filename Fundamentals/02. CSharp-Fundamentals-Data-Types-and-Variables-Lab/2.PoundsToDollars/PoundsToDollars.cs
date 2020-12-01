using System;

namespace _2.PoundsToDollars
{
    class PoundsToDollars
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            

            Console.WriteLine($"{(decimal)1.31 * pounds:f3}");
        }
    }
}
