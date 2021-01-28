using System;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = tokens[0];
            int end = tokens[1];
            string conditoin = Console.ReadLine();

            PrintNumbers(start, end, GetConditoin(conditoin));

        }

        private static void PrintNumbers(int start, int end, Predicate<int> condition)
        {
            for (int i = start; i <= end; i++)
            {
                if (condition(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Predicate<int> GetConditoin(string condition)
        {
            if (condition == "odd")
            {
                return x => (x & 1) == 1;
            }
            else
            {
                return x => (x & 1) == 0;
            }
        }
    }
}
