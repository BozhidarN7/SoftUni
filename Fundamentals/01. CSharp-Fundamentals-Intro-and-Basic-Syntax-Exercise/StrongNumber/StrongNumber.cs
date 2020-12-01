using System;

namespace StrongNumber
{
    class StrongNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copiedNumber = number;
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                sum += CalculateFactorial(digit);
                number /= 10;
            }

            if (sum == copiedNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static int CalculateFactorial(int n)
        {
            int result = 1;
            for (int  i =2;i <=n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
