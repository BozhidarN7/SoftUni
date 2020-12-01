using System;
using System.Collections.Generic;

namespace _5.SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingSystem = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0] == "register")
                {
                    if (!parkingSystem.ContainsKey(tokens[1]))
                    {
                        parkingSystem.Add(tokens[1], tokens[2]);
                        Console.WriteLine($"{tokens[1]} registered {tokens[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {tokens[2]}");
                    }
                }
                else
                {
                    if (!parkingSystem.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"ERROR: user {tokens[1]} not found");
                    }
                    else
                    {
                        parkingSystem.Remove(tokens[1]);
                        Console.WriteLine($"{tokens[1]} unregistered successfully");
                    }
                }
            }

            foreach (var car in parkingSystem)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
