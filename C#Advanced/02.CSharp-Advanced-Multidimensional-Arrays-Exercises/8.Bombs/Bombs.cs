using System;
using System.Linq;

namespace _8.Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < bombs.Length; i++)
            {
                int row = bombs[i][0] - '0';
                int col = bombs[i][2] - '0';
                int value = matrix[row, col];
                if (value <= 0) continue;
                Explode(matrix, row, col, value, n);

            }

            int aliveCells = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        aliveCells++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix, n);

        }

        private static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(((matrix[i, j] == int.MaxValue) ? 0 : matrix[i, j]) + ((j != n - 1) ? " " : ""));
                }
                Console.WriteLine();
            }
        }

        private static void Explode(int[,] matrix, int row, int col, int value, int n)
        {

            int rowIndex = row + 1;
            int colIndex = col;
            Subtract(matrix, rowIndex, colIndex, value, n);

            rowIndex = row - 1;
            colIndex = col;
            Subtract(matrix, rowIndex, colIndex, value, n);

            rowIndex = row;
            colIndex = col + 1;
            Subtract(matrix, rowIndex, colIndex, value, n);

            rowIndex = row;
            colIndex = col - 1;
            Subtract(matrix, rowIndex, colIndex, value, n);

            rowIndex = row + 1;
            colIndex = col - 1;
            Subtract(matrix, rowIndex, colIndex, value, n);

            rowIndex = row - 1;
            colIndex = col + 1;
            Subtract(matrix, rowIndex, colIndex, value, n);


            rowIndex = row + 1;
            colIndex = col + 1;
            Subtract(matrix, rowIndex, colIndex, value, n);


            rowIndex = row - 1;
            colIndex = col - 1;
            Subtract(matrix, rowIndex, colIndex, value, n);

            matrix[row, col] = 0;

        }

        private static void Subtract(int[,] matrix, int rowIndex, int colIndex, int value, int n)
        {
            if (IsValid(rowIndex, colIndex, n) && matrix[rowIndex, colIndex] > 0)
            {
                matrix[rowIndex, colIndex] -= value;
            }
        }

        private static bool IsValid(int rowIndex, int colIndex, int n)
        {
            return rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < n;
        }
    }
}
