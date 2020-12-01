using System;

namespace TheatrePromotions
{
    class TheatrePromotions
    {

        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int[] weekdayPrize = { 12, 18, 12 };
            int[] weekendPrize = { 15, 20, 15 };
            int[] holidayPrize = { 5, 12, 10 };

            if (dayType == "Weekday")
            {
                int prize = CheckPrizeByAge(weekdayPrize, age);
                IzPrizeEqualZero(prize);
                Console.WriteLine($"{prize}$");
            }
            else if (dayType == "Weekend")
            {
                int prize = CheckPrizeByAge(weekendPrize, age);
                IzPrizeEqualZero(prize);
                Console.WriteLine($"{prize}$");
            }
            else
            {
                int prize = CheckPrizeByAge(holidayPrize, age);
                IzPrizeEqualZero(prize);
                Console.WriteLine($"{prize}$");
            }
        }

        private static void IzPrizeEqualZero(int prize)
        {
            if (prize == 0)
            {
                Console.WriteLine("Error!");
                Environment.Exit(0);

            }
            else
            {
                return;
            }
        }

        private static int CheckPrizeByAge(int[] prizes, int age)
        {
            if (age >= 0 && age <= 18)
            {
                return prizes[0];
            }
            else if (age > 18 && age <= 64)
            {
                return prizes[1];
            }
            else if (age > 64 && age <= 122)
            {
                return prizes[2];
            }
            else
            {
                return 0;
            }
        }
    }
}
