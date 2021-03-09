using System;

namespace _1.Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IVehicle car = new Car(double.Parse(tokens[1]),double.Parse(tokens[2]));

            tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IVehicle truck = new Truck(double.Parse(tokens[1]), double.Parse(tokens[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Drive")
                {
                    if (tokens[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(tokens[2])));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(double.Parse(tokens[2])));
                    }
                }
                else
                {
                    if (tokens[1] == "Car")
                    {
                        car.Refuel(double.Parse(tokens[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(tokens[2]));
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
