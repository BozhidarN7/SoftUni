using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = indexes[0];
            int second = indexes[1];

            Box<int>.Swap(boxes, first, second);
            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}