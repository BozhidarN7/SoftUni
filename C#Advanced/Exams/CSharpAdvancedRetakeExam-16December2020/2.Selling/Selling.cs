using System;
using System.Collections.Generic;

namespace _2.Selling
{
    class Selling
    {
        private const int MIN_MONEY = 50;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;
            KeyValuePair<int, int>[] portals = new KeyValuePair<int, int>[2];
            int portalNumber = 0;
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
                        matrix[row, col] = '-';
                    }
                    if (matrix[i, j] == 'O')
                    {
                        portals[portalNumber++] = new KeyValuePair<int, int>(i, j);
                    }
                }
            }

            int money = 0;
            bool result = MoveThroughTheMatrix(matrix, portals, row, col, ref money, n);

            if (result)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {money}");
            PrintMatrix(matrix, n);
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int i = 0; i< n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool MoveThroughTheMatrix(char[,] matrix, KeyValuePair<int, int>[] portals, int row, int col, ref int money, int n)
        {
            bool success = false;
            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    row -= 1;
                }
                if (direction == "down")
                {
                    row += 1;
                }
                if (direction == "left")
                {
                    col -= 1;
                }
                if (direction == "right")
                {
                    col += 1;
                }

                if (!IsInBounds(row, col, n))
                {
                    break;
                }
                if (matrix[row, col] == 'O')
                {
                    (int newRow, int newCol) = Teleport(matrix, portals, row, col);
                    row = newRow;
                    col = newCol;
                }

                if (matrix[row, col] >= '0' && matrix[row, col] <= '9')
                {
                    money += matrix[row, col] - '0';
                    matrix[row, col] = '-';
                }

                if (money >= MIN_MONEY)
                {
                    success = true;
                    break;
                }
            }
            if (success)
            {
                matrix[row, col] = 'S';
            }

            return success;
        }

        private static (int newRow, int newCol) Teleport(char[,] matrix, KeyValuePair<int, int>[] portals, int row, int col)
        {
            matrix[portals[0].Key, portals[0].Value] = '-';
            matrix[portals[1].Key, portals[1].Value] = '-';
            if (row == portals[0].Key && col == portals[0].Value)
            {
                return (portals[1].Key, portals[1].Value);
            }
            else
            {
                return (portals[0].Key, portals[0].Value);
            }
        }

        private static bool IsInBounds(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
