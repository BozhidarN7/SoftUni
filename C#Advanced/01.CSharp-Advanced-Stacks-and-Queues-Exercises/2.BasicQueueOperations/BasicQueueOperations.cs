using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = tokens[0];
            int S = tokens[1];
            int X = tokens[2];

            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            while(numbers.Count != 0 && S != 0)
            {
                numbers.Dequeue();
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
                Console.WriteLine(numbers.Min() );
            }
        }
    }
}
