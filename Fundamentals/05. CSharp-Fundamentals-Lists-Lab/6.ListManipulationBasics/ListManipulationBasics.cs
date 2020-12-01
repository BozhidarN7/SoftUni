using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                else if (tokens[0] == "Remove")
                {
                    numbers.Remove(int.Parse(tokens[1]));
                }
                else if (tokens[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(tokens[1]));
                }
                else
                {
                    numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
