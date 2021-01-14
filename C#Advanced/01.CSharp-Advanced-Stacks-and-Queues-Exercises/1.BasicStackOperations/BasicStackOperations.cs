using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = tokens[0];
            int S = tokens[1];
            int X = tokens[2];

            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            while (numbers.Count > 0 && S > 0)
            {
                numbers.Pop();
                S--;
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
