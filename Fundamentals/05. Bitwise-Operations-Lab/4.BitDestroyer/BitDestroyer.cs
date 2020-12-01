using System;

namespace _4.BitDestroyer
{
    class BitDestroyer
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            Console.WriteLine(number &( ~(1<< p)));
        }
    }
}
