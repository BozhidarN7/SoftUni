using System;
using System.Collections.Generic;

namespace _6.ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string input = Console.ReadLine();
            while(input != "END")
            {
                string[] tokens = input.Split(", ");
                if (tokens[0] == "IN")
                {
                    cars.Add(tokens[1]);
                }
                else
                {
                    cars.Remove(tokens[1]);
                }
                input = Console.ReadLine();
            }
            if (cars.Count != 0)
            {
                Console.WriteLine(string.Join("\n",cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
