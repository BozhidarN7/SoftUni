using System;
using System.Collections.Generic;

namespace _3.SpeedRacing
{
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                cars.Add(new Car(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2])));
            }

            string command = Console.ReadLine();
            while (command !="End")
            {
                string[] tokens = command.Split();
                int carIndex = cars.FindIndex(x => x.Model == tokens[1]);
                cars[carIndex].Drive(int.Parse(tokens[2]));

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = 0;
        }

        public void Drive(int distanceToTravel)
        {
            double fuelNeeded = FuelConsumption * distanceToTravel;
            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                if (FuelAmount < 0)
                {
                    FuelAmount = 0;
                }
                TraveledDistance += distanceToTravel;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
