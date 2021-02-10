using System;
using System.Linq;

namespace _2.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;

            for (int i = 0; i < n; i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == 'f')
                    {
                        row = i;
                        col = j;
                        matrix[row, col] = '-';
                    }
                }
            }

            bool result = MoveThroughTheMatrix(matrix, n, count, row, col);
            if (result)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix, n);
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int i = 0;  i< n; i++)
            {
                for(int j = 0; j< n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool MoveThroughTheMatrix(char[,] matrix, int n, int count, int row, int col)
        {
            bool hasWon = false;
            int steps = 0;
            while (true)
            {
                string direction = Console.ReadLine();
                if (row == n)
                {
                    row = 0;
                }
                if (row == -1)
                {
                    row = n - 1;
                }
                if (col == n)
                {
                    col = 0;
                }
                if (col == -1)
                {
                    col = n - 1;
                }

                if (matrix[row, col] == 'F')
                {
                    matrix[row, col] = 'f';
                    hasWon = true;
                    break;
                }
                if (steps == count)
                {
                    matrix[row, col] = 'f';
                    break;
                }

                if (direction == "down")
                {
                    row += 1;
                    if (row == n)
                    {
                        row = 0;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        row += 1;
                    }
                    else if (matrix[row, col] == 'T')
                    {
                        row -= 1;
                    }
                }
                if (direction == "up")
                {
                    row -= 1;
                    if (row == -1)
                    {
                        row = n - 1;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        row -= 1;
                    }
                    else if (matrix[row, col] == 'T')
                    {
                        row += 1;
                    }
                }
                if (direction == "right")
                {
                    col += 1;
                    if (col == n)
                    {
                        col = 0;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        col += 1;
                    }
                    else if (matrix[row, col] == 'T')
                    {
                        col -= 1;
                    }
                }
                if (direction == "left")
                {
                    col -= 1;
                    if (col == -1)
                    {
                        col = n - 1;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        col -= 1;
                    }
                    else if (matrix[row, col] == 'T')
                    {
                        col += 1;
                    }
                }

                steps++;
            }

            return hasWon;
        }
    }
}
