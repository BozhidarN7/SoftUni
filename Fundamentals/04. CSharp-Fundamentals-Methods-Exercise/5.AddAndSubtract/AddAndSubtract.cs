using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace _5.AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = Add(a, b);
            int difference = Subtract(sum,c);
            Console.WriteLine(difference);
        }

        private static int Subtract(int sum, int c)
        {
            return sum - c;
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
