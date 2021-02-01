using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);
                cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();
                cars[tokens[1]].Drive(double.Parse(tokens[2]));
                command = Console.ReadLine();
            }

            foreach((string model, Car car) in cars)
            {
                Console.WriteLine($"{model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
