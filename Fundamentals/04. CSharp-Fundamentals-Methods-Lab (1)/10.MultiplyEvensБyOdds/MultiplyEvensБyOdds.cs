using System;

namespace _10.MultiplyEvensБyOdds
{
    class MultiplyEvensБyOdds
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvenAndOdds(number);

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = 0;
            int oddSum = 0;
            int iteration = 0;
            while (number != 0)
            {
                if (iteration % 2==0)
                {
                    evenSum += number % 10;
                }
                else
                {
                    oddSum += number % 10;
                }
                iteration++;
                number /= 10;
            }

            return evenSum * oddSum;
        }
    }
}
