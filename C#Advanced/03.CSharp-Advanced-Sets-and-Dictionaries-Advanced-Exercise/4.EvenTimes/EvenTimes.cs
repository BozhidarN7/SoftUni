using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> elements = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (!elements.ContainsKey(element))
                {
                    elements.Add(element, 0);
                }
                elements[element]++;
            }

            Console.WriteLine(elements.Where(x => x.Value % 2 == 0).ToArray()[0].Key);
        }
    }
}
