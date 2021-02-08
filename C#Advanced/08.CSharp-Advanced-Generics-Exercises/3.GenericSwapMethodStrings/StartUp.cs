using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = indexes[0];
            int second = indexes[1];

            Box<string>.Swap(boxes, first, second);
            foreach(Box<string> box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
