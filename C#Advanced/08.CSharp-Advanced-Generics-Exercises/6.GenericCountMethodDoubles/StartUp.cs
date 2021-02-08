using System;
using System.Collections.Generic;

namespace _6.GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }
            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(Box<double>.FindEqualElToGiven(boxes, element));
        }
    }
}
