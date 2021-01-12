using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int allowedToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();
            int totalCarsCrossed = 0;
            while (input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < allowedToPass; i++)
                    {
                        if (cars.Count != 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsCrossed++;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsCrossed} cars passed the crossroads.");
        }
    }
}
