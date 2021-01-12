﻿using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (names.Count != 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    continue;
                }
                names.Enqueue(input);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
