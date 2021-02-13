using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] dismensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dismensions[0];
            int cols = dismensions[1];

            int[,] matrix = new int[rows, cols];
            Queue<KeyValuePair<int, int>> flowers = new Queue<KeyValuePair<int, int>>();
            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] tokens = input.Split().Select(int.Parse).ToArray();
                if (AreValidIndexes(tokens[0], tokens[1], rows, cols))
                {
                    flowers.Enqueue(new KeyValuePair<int, int>(tokens[0], tokens[1]));
                    matrix[tokens[0], tokens[1]] = 1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                input = Console.ReadLine();
            }

            Bloom(matrix, flowers, rows, cols);
            PrintMatrix(matrix, rows, cols);
        }

        private static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j  = 0; j< cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Bloom(int[,] matrix, Queue<KeyValuePair<int, int>> flowers, int rows, int cols)
        {
            while (flowers.Count != 0)
            {
                KeyValuePair<int, int> current = flowers.Dequeue();
                int row = current.Key;
                int col = current.Value;

                for (int i = row + 1; i < rows; i++)
                {
                    matrix[i, col] += 1;
                }
                for (int i = row - 1; i >= 0; i--)
                {
                    matrix[i, col] += 1;
                }
                for (int j = col + 1; j < cols; j++)
                {
                    matrix[row, j] += 1;
                }
                for (int j = col - 1; j >= 0; j--)
                {
                    matrix[row, j] += 1;
                }
            }
        }

        private static bool AreValidIndexes(int row, int col, int rows, int cols)
        {
            return row >= 0 & row < rows && col >= 0 && col < cols;
        }
    }
}
