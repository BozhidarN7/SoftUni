using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _4.RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                cars.Add(new Car(tokens[0], new Engine(int.Parse(tokens[1]), int.Parse(tokens[2])), new Cargo(int.Parse(tokens[3]), tokens[4])));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(x => x.CargoSettings.Type == command && x.CargoSettings.Weight < 1000).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Model);
                });
            }
            else
            {
                cars.Where(x => x.CargoSettings.Type == command && x.EnginePerformance.Power > 250).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Model);
                });
            }
        }
    }

    class Car
    {
        public string Model { get; set; }

        public Engine EnginePerformance { get; set; }
        public Cargo CargoSettings { get; set; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            EnginePerformance = engine;
            CargoSettings = cargo;
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

}
