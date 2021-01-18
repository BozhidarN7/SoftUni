using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            string[,] matrix = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data[0] != "swap" || data.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                int row1 = int.Parse(data[1]);
                int col1 = int.Parse(data[2]);
                int row2 = int.Parse(data[3]);
                int col2 = int.Parse(data[4]);

                if (!CheckIndexes(row1, col1, row2, col2, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;
                PrintMatrix(matrix, rows, cols);
                command = Console.ReadLine();
            }
        }

        private static bool CheckIndexes(int row1, int col1, int row2, int col2, int rows, int cols)
        {
            return row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows && col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols;
        }

        private static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
