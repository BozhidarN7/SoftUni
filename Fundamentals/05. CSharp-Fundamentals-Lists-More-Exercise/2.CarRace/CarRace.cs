using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine().Split().Select(int.Parse).ToList();

            double leftRacer = 0;
            for (int i = 0; i < times.Count / 2; i++)
            {
                leftRacer = (times[i] != 0 ? times[i] + leftRacer : leftRacer * 0.8);
            }

            double rightRacer = 0;
            for (int i = times.Count - 1; i > times.Count / 2; i--)
            {
                rightRacer = (times[i] != 0 ? times[i] + rightRacer : rightRacer * 0.8);
            }


            if (leftRacer < rightRacer)
            {
                Console.WriteLine($"The winner is left with total time: {leftRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightRacer}");
            }
        }
    }
}
