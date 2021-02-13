using System;
using System.Collections.Generic;

namespace _2.Snake
{
    class Snake
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;

            KeyValuePair<int, int>[] lair = new KeyValuePair<int, int>[2];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                    if (matrix[i, j] == 'B')
                    {
                        lair[index++] = new KeyValuePair<int, int>(i, j);
                    }
                }
            }

            int foodEaten = 0;
            MoveThroughTheMatrix(matrix, lair, row, col, ref foodEaten, n);

            if (foodEaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix, n);
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveThroughTheMatrix(char[,] matrix, KeyValuePair<int, int>[] lair, int row, int col, ref int foodEaten, int n)
        {
            while (true)
            {
                string direction = Console.ReadLine();
                matrix[row, col] = '.';

                if (direction == "up") row--;
                if (direction == "down") row++;
                if (direction == "right") col++;
                if (direction == "left") col--;

                if (IsOutOfBounds(row, col, n))
                {
                    break;
                }
                if (matrix[row, col] == '*')
                {
                    foodEaten++;
                    if (foodEaten >= 10)
                    {
                        matrix[row, col] = 'S';
                        break;
                    }
                }
                if (matrix[row, col] == 'B')
                {
                    Teleport(matrix, lair, ref row, ref col);
                }
            }
        }

        private static void Teleport(char[,] matrix, KeyValuePair<int, int>[] lair, ref int row, ref int col)
        {
            matrix[lair[0].Key, lair[0].Value] = '.';
            matrix[lair[1].Key, lair[1].Value] = '.';

            if (row == lair[0].Key && col == lair[0].Value)
            {
                row = lair[1].Key;
                col = lair[1].Value;
            }
            else
            {
                row = lair[0].Key;
                col = lair[0].Value;
            }
        }

        private static bool IsOutOfBounds(int row, int col, int n)
        {
            return row < 0 || row >= n || col < 0 || col >= n;
        }
    }
}
