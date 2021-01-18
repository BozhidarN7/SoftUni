using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int primaryDiagonalSum = 0;
            for (int i = 0; i < n; i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }
            int secondaryDiagonalSum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                secondaryDiagonalSum += matrix[n -i - 1, i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}

