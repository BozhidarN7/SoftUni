using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];
            int[,] matrix = new int[rows, cols];

            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                    sum += matrix[i, j];
                }
            }

          

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
