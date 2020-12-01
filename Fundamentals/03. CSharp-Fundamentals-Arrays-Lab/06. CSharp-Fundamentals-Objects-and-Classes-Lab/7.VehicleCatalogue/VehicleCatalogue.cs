using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.VehicleCatalogue
{
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split('/');

                if (tokens[0] == "Car")
                {
                    catalog.Cars.Add(new Car { Brand = tokens[1], Model = tokens[2], HorsePower = int.Parse(tokens[3]) });
                }
                else
                {
                    catalog.Trucks.Add(new Truck { Brand = tokens[1], Model = tokens[2], Weight = int.Parse(tokens[3]) });

                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Cars:");
            catalog.Cars.OrderBy(x=> x.Brand).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Brand}: {x.Model} - {x.HorsePower}hp");
            });

            Console.WriteLine("Trucks:");
            catalog.Trucks.OrderBy(x => x.Brand).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Brand}: {x.Model} - {x.Weight}kg");
            });

        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
