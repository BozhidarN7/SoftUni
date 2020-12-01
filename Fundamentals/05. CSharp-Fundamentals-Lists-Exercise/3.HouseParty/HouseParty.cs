using System;
using System.Collections.Generic;

namespace _3.HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int numberOfcommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int c = 0; c < numberOfcommands; c++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                if (tokens[2] != "not")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", guests));
        }
    }
}
