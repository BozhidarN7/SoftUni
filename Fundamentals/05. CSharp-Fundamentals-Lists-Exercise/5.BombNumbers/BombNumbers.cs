using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = tokens[0];
            int range = tokens[1];

            int index = numbers.IndexOf(bombNumber);
            while (index != -1)
            {
                int leftSize = (index - range >= 0) ? index - range : 0;
                int rightSize = (index + range < numbers.Count) ? range : numbers.Count - index - 1;
                numbers.RemoveRange(leftSize, (index - leftSize) + rightSize + 1);

                index = numbers.IndexOf(bombNumber);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
