using System;

namespace _8.FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());
            long b = long.Parse(Console.ReadLine());

            long factorialA = CalculateFactorial(a);
            long factorialB = CalculateFactorial(b);
            double result = (double)factorialA / (double)factorialB;

            Console.WriteLine($"{result:f2}");
        }

        private static long CalculateFactorial(long number)
        {
            long result = 1;
            for (long i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
