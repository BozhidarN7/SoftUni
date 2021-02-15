using System;

namespace _2.RecursiveFactorial
{
    class RecursiveFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(n));
        }

        private static int CalculateFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
