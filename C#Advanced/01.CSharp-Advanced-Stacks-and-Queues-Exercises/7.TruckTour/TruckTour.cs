using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Truck> trucks = new Queue<Truck>();
            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                trucks.Enqueue(new Truck(i, tokens[0], tokens[1]));
            }

            Truck startTruck = trucks.Dequeue();
            Truck previousTruck = startTruck;
            int fuel = 0;
            trucks.Enqueue(startTruck);
            while (true)
            {
                fuel += previousTruck.petrolGived;
                Truck currentTruck = trucks.Dequeue();
                if (previousTruck.DistanceNext <= fuel && currentTruck == startTruck)
                {
                    break;
                }
                if (previousTruck.DistanceNext <= fuel)
                {
                    fuel -= previousTruck.DistanceNext;
                }
                else
                {
                    fuel = 0;
                    startTruck = currentTruck;
                }
                previousTruck = currentTruck;
                trucks.Enqueue(previousTruck);
            }
            Console.WriteLine(startTruck.Index);
        }
    }

    public class Truck
    {
        public int Index { get; set; }
        public int DistanceNext { get; set; }
        public int petrolGived { get; set; }

        public Truck(int index, int petrolGived, int distanceNext)
        {
            this.Index = index;
            this.DistanceNext = distanceNext;
            this.petrolGived = petrolGived;
        }
    }
}
