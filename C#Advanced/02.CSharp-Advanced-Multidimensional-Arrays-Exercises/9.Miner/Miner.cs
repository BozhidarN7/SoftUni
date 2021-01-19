using System;
using System.Linq;

namespace _9.Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;
            int totalCoals = 0;
            for (int i = 0; i < n; i++)
            {
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == 's')
                    {
                        row = i;
                        col = j;
                    }
                    if (matrix[i, j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            int collectedCoals = 0;
            foreach (string move in moves)
            {
                if (move == "up" && IsValid(row - 1, col, n))
                {
                    row--;
                    if (Move(matrix, row, col, ref collectedCoals, totalCoals)) return;
                }
                else if (move == "down" && IsValid(row + 1, col, n))
                {
                    row++;
                    if (Move(matrix, row, col, ref collectedCoals, totalCoals)) return;
                }
                else if (move == "left" && IsValid(row, col - 1, n))
                {
                    col--;
                    if (Move(matrix, row, col, ref collectedCoals, totalCoals)) return;
                }
                else if (move == "right" && IsValid(row, col + 1, n))
                {
                    col++;
                    if (Move(matrix, row, col, ref collectedCoals, totalCoals)) return;
                }

            }
            Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({row}, {col})");
        }

        private static bool Move(char[,] matrix, int row, int col, ref int collectedCoals, int totalCoals)
        {
            if (matrix[row, col] == 'c')
            {
                collectedCoals++;
                matrix[row, col] = '*';

                if (collectedCoals == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return true;
                }
            }
            else if (matrix[row, col] == 'e')
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                return true;
            }

            return false;
        }

        private static bool IsValid(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
