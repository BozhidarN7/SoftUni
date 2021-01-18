using System;
using System.Linq;

namespace _2._2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int equal2x2Matrixex = FindEqual2x2Matrixes(matrix, rows, cols);

            Console.WriteLine(equal2x2Matrixex);
        }

        private static int FindEqual2x2Matrixes(char[,] matrix, int rows, int cols)
        {
            int result = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
