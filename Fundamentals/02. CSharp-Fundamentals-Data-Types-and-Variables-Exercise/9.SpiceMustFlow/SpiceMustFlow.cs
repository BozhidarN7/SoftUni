using System;

namespace _9.SpiceMustFlow
{
    class SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int result = 0;
            int days = 0;

            while (startingYield >= 100)
            {
                result += startingYield - 26;
                days++;
                startingYield -= 10;
            }
            if (result != 0)
            {
                result -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(result);
        }
    }
}
