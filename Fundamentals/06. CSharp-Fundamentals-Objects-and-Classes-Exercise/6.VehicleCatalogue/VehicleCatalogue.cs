using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();

                vehicles.Add(new Vehicle(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3])));

                input = Console.ReadLine();
            }

            string model = Console.ReadLine();
            while (model != "Close the Catalogue")
            {
                List<Vehicle> current = vehicles.Where(x => x.Model == model).ToList();
                foreach (Vehicle vehicle in current)
                {
                    Console.WriteLine($"Type: {vehicle.Type.First().ToString().ToUpper() + vehicle.Type.Substring(1)}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                }
                model = Console.ReadLine();
            }
            int numberOfCars = vehicles.Where(x => x.Type == "car").Count();
            int numberOfTrucks = vehicles.Count - numberOfCars;
            double carsAverageHorsePower = (double)vehicles.Where(x => x.Type == "car").Select(x => x.HorsePower).Sum() / numberOfCars;
            double trucksAverageHorsePower = (double)vehicles.Where(x => x.Type == "truck").Select(x => x.HorsePower).Sum() / numberOfTrucks;

            if (numberOfCars > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (numberOfTrucks > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }


        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
    }
}
