using System;

namespace _5.MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            string sign = FindSignOfMultiplication(num1, num2, num3);
            Console.WriteLine(sign);
        }

        private static string FindSignOfMultiplication(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                return "zero";
            }

            int negative = 0;
            if (num1 < 0)
            {
                negative++;
            }
            if (num2 < 0)
            {
                negative++;
            }
            if (num3 < 0)
            {
                negative++;
            }

            if (negative == 1 || negative ==3 )
            {
                return "negative";
            }
            return "positive";
        }
    }
}
