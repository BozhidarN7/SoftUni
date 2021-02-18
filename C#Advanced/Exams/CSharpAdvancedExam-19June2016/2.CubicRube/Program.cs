using System;
using System.Linq;

namespace _2.CubicRube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalCells = (int)Math.Pow(n, 3);

            long totalSum = 0;
            int totalChanged = 0;
            string input = Console.ReadLine();
            while (input != "Analyze")
            {
                int[] data = input.Split().Select(int.Parse).ToArray();

                if (data[3] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (IsValid(data[0], data[1], data[2], n))
                {
                    totalChanged++;
                    totalSum += data[3];
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
            Console.WriteLine(totalCells - totalChanged);
        }

        private static bool IsValid(int x, int y, int z, int n)
        {
            return x >= 0 && x < n && y >= 0 && y < n && z >= 0 && z < n;
        }
    }
}
