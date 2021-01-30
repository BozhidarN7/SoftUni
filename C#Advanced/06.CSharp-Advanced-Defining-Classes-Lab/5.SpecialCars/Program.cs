using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<Tire>> tires = new List<List<Tire>>();
            List<Engine> engines = new List<Engine>();
            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                tires.Add(new List<Tire>());
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);
                    tires[tires.Count - 1].Add(new Tire(year, pressure));
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));

                input = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex].ToArray()));

                input = Console.ReadLine();
            }

            cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9
            && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList()
                .ForEach(x =>
            {
                x.Drive(20);
                Console.WriteLine(x.Print());
            });
        }
    }
}
