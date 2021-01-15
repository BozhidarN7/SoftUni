using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            int maxSum = 0;
            int row = 0;
            int col = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int squareSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (squareSum > maxSum)
                    {
                        maxSum = squareSum;
                        row = i;
                        col = j;
                    }
                }
            }

            for (int i = row; i< row + 2; i++)
            {
                for (int j = col; j < col + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
