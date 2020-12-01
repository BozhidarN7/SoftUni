using System;
using System.Runtime.InteropServices;

namespace _7.WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int capacity = 255;
            int currentCapacity = 0;
            for (int i = 0; i < n; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());
                currentCapacity += quantityOfWater;
                if (currentCapacity > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    currentCapacity -= quantityOfWater;
                }
            }

            Console.WriteLine(currentCapacity);
        }
    }
}
