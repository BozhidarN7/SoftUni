using System;
using System.Linq;

namespace _3.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int n = 3;
            int maxSum = 0;
            int startRow = 0;
            int startCol = 0;
            for (int i = 0; i < rows - n + 1; i++)
            {
                for (int j = 0; j < cols - n + 1; j++)
                {
                    int currentSum = 0;
                    for (int row = i; row < n + i; row++)
                    {
                        for (int col = j; col < n + j; col++)
                        {
                            currentSum += matrix[row, col];
                        }
                    }
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        startRow = i;
                        startCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = startRow; i < n + startRow; i++)
            {
                for (int j = startCol; j < n + startCol; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
