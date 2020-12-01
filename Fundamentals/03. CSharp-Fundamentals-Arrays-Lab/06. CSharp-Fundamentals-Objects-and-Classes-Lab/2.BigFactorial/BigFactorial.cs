using System;
using System.Numerics;

namespace _2.BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger result = CalculateFactorial(n);

            Console.WriteLine(result);
        }

        private static BigInteger CalculateFactorial(int n)
        {
            if (n == 1)
            {
                 return 1;
            }

            return CalculateFactorial(n - 1) * n;
        }
    }
}
