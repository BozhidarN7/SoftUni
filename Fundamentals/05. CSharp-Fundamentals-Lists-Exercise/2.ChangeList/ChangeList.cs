using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(tokens[1]));
                }
                else
                {
                    numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
