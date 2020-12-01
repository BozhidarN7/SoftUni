using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool hasChange = false;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                    hasChange = true;
                }
                else if (tokens[0] == "Remove")
                {
                    numbers.Remove(int.Parse(tokens[1]));
                    hasChange = true;
                }
                else if (tokens[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(tokens[1]));
                    hasChange = true;
                }
                else if (tokens[0] == "Insert")
                {
                    numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                    hasChange = true;
                }
                else if (tokens[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(tokens[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (tokens[0] == "PrintEven")
                {
                    numbers.ForEach(x =>
                    {
                        if (x % 2 == 0)
                        {
                            Console.Write(x + " ");
                        }
                    });
                    Console.WriteLine();
                }
                else if (tokens[0] == "PrintOdd")
                {
                    numbers.ForEach(x =>
                    {
                        if (x % 2 != 0)
                        {
                            Console.Write(x + " ");
                        }
                    });
                    Console.WriteLine();
                }
                else if (tokens[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else
                {
                    if (tokens[1] == ">")
                    {
                        numbers.ForEach(x =>
                        {
                            if (x > int.Parse(tokens[2]))
                            {
                                Console.Write(x + " ");
                            }
                        });
                        Console.WriteLine();
                    }
                    else if (tokens[1] == "<")
                    {
                        numbers.ForEach(x =>
                        {
                            if (x < int.Parse(tokens[2]))
                            {
                                Console.Write(x + " ");
                            }
                        });
                        Console.WriteLine();
                    }
                    else if (tokens[1] == ">=")
                    {
                        numbers.ForEach(x =>
                        {
                            if (x >= int.Parse(tokens[2]))
                            {
                                Console.Write(x + " ");
                            }
                        });
                        Console.WriteLine();
                    }
                    else
                    {
                        numbers.ForEach(x =>
                        {
                            if (x <= int.Parse(tokens[2]))
                            {
                                Console.Write(x + " ");
                            }
                        });
                        Console.WriteLine();
                    }
                }
            }

            if (hasChange)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
