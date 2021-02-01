using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string power = tokens[1];
                string displacement = null;
                string efficiency = null;

                if (tokens.Length >= 3 && char.IsDigit(tokens[2],0))
                {
                    displacement = tokens[2];
                }
                if (tokens.Length >= 3 && !char.IsDigit(tokens[2], 0))
                {
                    efficiency = tokens[2];
                }
                if (tokens.Length == 4)
                {
                    displacement = tokens[2];
                    efficiency = tokens[3];
                }

                engines.Add(new Engine(model, power, (displacement is null) ? null : displacement, (efficiency is null) ? null : efficiency));
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {

                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];
                string weight = null;
                string color = null;

                if (tokens.Length >= 3 && char.IsDigit(tokens[2], 0))
                {
                    weight = tokens[2];
                }
                if (tokens.Length >= 3 && !char.IsDigit(tokens[2], 0))
                {
                    color = tokens[2];
                }
                if (tokens.Length == 4)
                {
                    weight = tokens[2];
                    color = tokens[3];
                }
                cars.Add(new Car(model, engines.Where(x => x.Model == engineModel).FirstOrDefault(), (weight is null) ? null : weight, (color is null) ? null : color));

            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"\t{car.Engine.Model}:");
                Console.WriteLine($"\t\tPower: {car.Engine.Power}");
                Console.WriteLine($"\t\tDisplacement: {((car.Engine.Displacement is null) ? "n/a" : car.Engine.Displacement)}");
                Console.WriteLine($"\t\tEfficiency: {((car.Engine.Efficiency is null) ? "n/a" : car.Engine.Efficiency)}");
                Console.WriteLine($"\tWeight: {((car.Weight is null) ? "n/a" : car.Weight)}");
                Console.WriteLine($"\tColor: {((car.Color is null) ? "n/a" : car.Color)}");
            }
        }
    }
}
