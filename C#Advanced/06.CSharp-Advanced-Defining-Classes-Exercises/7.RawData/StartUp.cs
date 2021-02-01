using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                List<Tire> tires = new List<Tire>();
                for (int j = 5; j <= 12; j += 2)
                {
                    tires.Add(new Tire(double.Parse(tokens[j]), int.Parse(tokens[j + 1])));
                }
                cars.Add(new Car(tokens[0], engine, cargo, tires));
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Where(y => y.Pressure < 1).Count() != 0).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            if (command == "flamable")
            {
                cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
