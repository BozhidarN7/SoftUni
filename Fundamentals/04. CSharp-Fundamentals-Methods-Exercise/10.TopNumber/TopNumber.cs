using System;

namespace _10.TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i< n; i++)
            {
                bool isTopNumber = CheckIfNumberIsTopNumber(i);

                if (isTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
            
        }

        private static bool CheckIfNumberIsTopNumber(int number)
        {
            int sumOfDigits = 0;
            int oddCount = 0;

            while (number != 0)
            {
                int digit = number % 10;
                sumOfDigits += digit;

                if (digit % 2 == 1)
                {
                    oddCount++;
                }

                number /= 10;
            }

            if (sumOfDigits % 8 != 0)
            {
                return false;
            }
            if (oddCount < 1)
            {
                return false;
            }
            return true;
        }
    }
}
