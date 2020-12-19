using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.NeedForSpeedIII
{
    class NeedForSpeedIII
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cars = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                string car = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);
                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new Dictionary<string, int>()
                    {
                        {"mileage",0 },
                        {"fuel",0 }
                    });
                }
                cars[car]["mileage"] = mileage;
                cars[car]["fuel"] = fuel;
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split(" : ");
                if (tokens[0] == "Drive")
                {
                    string car = tokens[1];
                    int mileage = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (cars[car]["fuel"] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car]["fuel"] -= fuel;
                        cars[car]["mileage"] += mileage;
                        Console.WriteLine($"{car} driven for {mileage} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[car]["mileage"] >= 100000)
                        {
                            Console.WriteLine("Time to sell the {0}!", car);
                            cars.Remove(car);
                        }
                    }
                }
                else if (tokens[0] == "Refuel")
                {
                    string car = tokens[1];
                    int fuel = int.Parse(tokens[2]);
                    int before = cars[car]["fuel"];
                    cars[car]["fuel"] += fuel;
                    if (cars[car]["fuel"] > 75)
                    {
                        Console.WriteLine($"{car} refueled with {75 - before} liters");
                        cars[car]["fuel"] = 75;
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else
                {
                    string car = tokens[1];
                    int mileage = int.Parse(tokens[2]);
                    cars[car]["mileage"] -= mileage;
                    if (cars[car]["mileage"] < 10000)
                    {
                        cars[car]["mileage"] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {mileage} kilometers");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Value["mileage"]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value["mileage"]} kms, Fuel in the tank: {car.Value["fuel"]} lt.");
            }
        }
    }
}
