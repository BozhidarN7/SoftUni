using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;

namespace _4.ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                else if (tokens[0] == "Insert")
                {
                    if ((int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < numbers.Count))
                    {
                        numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (tokens[0] == "Remove" && CheckIndex(int.Parse(tokens[1]), numbers.Count))
                {
                    numbers.RemoveAt(int.Parse(tokens[1]));
                }
                else if (tokens[1] == "left")
                {
                    ShiftLeft(numbers, int.Parse(tokens[2]));
                }
                else if (tokens[1] == "right")
                {
                    ShiftRight(numbers, int.Parse(tokens[2]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ShiftRight(List<int> numbers, int count)
        {
            int length = numbers.Count;
            int previous = numbers[0];
            int last = numbers[length - 1];

            for (int c = 0; c < count % numbers.Count; c++)
            {
                for (int i = 1; i < length; i++)
                {
                    int temp = numbers[i];
                    numbers[i] = previous;
                    previous = temp;
                }
                numbers[0] = last;
                previous = numbers[0];
                last = numbers[length - 1];
            }
        }

        private static void ShiftLeft(List<int> numbers, int count)
        {
            int length = numbers.Count;
            int last = numbers[length - 1];
            int first = numbers[0];

            for (int c = 0; c < count % numbers.Count; c++)
            {
                for (int i = length - 2; i >= 0; i--)
                {
                    int temp = numbers[i];
                    numbers[i] = last;
                    last = temp;
                }
                numbers[length - 1] = first;
                last = numbers[length - 1];
                first = numbers[0];
            }
        }

        private static bool CheckIndex(int index, int length)
        {
            if (index >= 0 && index < length)
            {
                return true;
            }
            Console.WriteLine("Invalid index");
            return false;
        }
    }
}
