using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }
            string element = Console.ReadLine();
            Console.WriteLine(Box<string>.FindEqualElToGiven(boxes,element));
        }
    }
}
