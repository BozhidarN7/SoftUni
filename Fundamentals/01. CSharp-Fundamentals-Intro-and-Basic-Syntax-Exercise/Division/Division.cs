using System;

namespace Division
{
    class Division
    {
        static void Main(string[] args)
        {

            int groupSize = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double totalPrice = 1.0;
            if (day == "Friday")
            {
                if (groupType == "Students")
                {
                    totalPrice *= 8.45 * groupSize;
                    if (groupSize >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
                else if (groupType == "Business")
                {
                    totalPrice *= 10.90 * groupSize;
                    if (groupSize >= 100)
                    {
                        totalPrice = totalPrice - 10 * 10.90;
                    }
                }
                else
                {
                    totalPrice *= 15 * groupSize;
                    if (groupSize >= 10 && groupSize <= 20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
            }
            else if (day == "Saturday")
            {
                if (groupType == "Students")
                {
                    totalPrice *= 9.80 * groupSize;
                    if (groupSize >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
                else if (groupType == "Business")
                {
                    totalPrice *= 15.60 * groupSize;
                    if (groupSize >= 100)
                    {
                        totalPrice = totalPrice - 10 * 15.60;
                    }
                }
                else
                {
                    totalPrice *= 20 * groupSize;
                    if (groupSize >= 10 && groupSize <= 20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
            }
            else
            {
                if (groupType == "Students")
                {
                    totalPrice *= 10.46 * groupSize;
                    if (groupSize >= 30)
                    {
                        totalPrice = totalPrice - totalPrice * 0.15;
                    }
                }
                else if (groupType == "Business")
                {
                    totalPrice *= 16 * groupSize;
                    if (groupSize >= 100)
                    {
                        totalPrice = totalPrice - 10 * 16;
                    }
                }
                else
                {
                    totalPrice *= 22.50 * groupSize;
                    if (groupSize >= 10 && groupSize <= 20)
                    {
                        totalPrice = totalPrice - totalPrice * 0.05;
                    }
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
