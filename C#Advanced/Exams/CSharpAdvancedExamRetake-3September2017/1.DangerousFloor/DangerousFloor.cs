using System;
using System.Linq;

namespace _1.DangerousFloor
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {
            int n = 8;
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] rowData = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            string movement = Console.ReadLine();
            while (movement != "END")
            {
                char piece = movement[0];
                string currentPos = movement.Substring(1, 2);
                string nextPos = movement.Substring(movement.IndexOf('-') + 1);

                int row = currentPos[0] - '0';
                int col = currentPos[1] - '0';
                int nextRow = nextPos[0] - '0';
                int nextCol = nextPos[1] - '0';

                if (matrix[row, col] == 'x' || IsOutOfBounds(row, col, n))
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (IsOutOfBounds(nextRow, nextCol, n))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else if (!IsMoveValid(piece, row, col, nextRow, nextCol, n))
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    char temp = matrix[row, col];
                    matrix[row, col] = 'x';
                    matrix[nextRow, nextCol] = temp;
                }
                movement = Console.ReadLine();
            }
        }

        private static bool IsMoveValid(char piece, int row, int col, int nextRow, int nextCol, int n)
        {
            if (piece == 'K')
            {
                if (CheckForK(row, col, nextRow, nextCol))
                {
                    return true;
                }
                return false;
            }
            else if (piece == 'P')
            {
                if (CheckForP(row, col, nextRow, nextCol))
                {
                    return true;
                }
                return false;
            }
            else if (piece == 'R')
            {
                if (CheckForR(row, col, nextRow, nextCol, n))
                {
                    return true;
                }
                return false;
            }
            else if (piece == 'B')
            {
                if (CheckForB(row, col, nextRow, nextCol, n))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (CheckForQ(row, col, nextRow, nextCol, n))
                {
                    return true;
                }
                return false;
            }
        }

        private static bool CheckForQ(int row, int col, int nextRow, int nextCol, int n)
        {
            if (CheckForB(row, col, nextRow, nextCol, n) || CheckForR(row, col, nextRow, nextCol, n))
            {
                return true;
            }
            return false;
        }

        private static bool CheckForB(int row, int col, int nextRow, int nextCol, int n)
        {
            int i = row + 1;
            int j = col + 1;

            while (i < n && j < n)
            {
                if (nextRow == i && nextCol == j)
                {
                    return true;
                }
                i += 1;
                j += 1;
            }
            i = row + 1;
            j = col - 1;
            while (i < n && j >= 0)
            {
                if (nextRow == i && nextCol == j)
                {
                    return true;
                }
                i++;
                j--;
            }
            i = row - 1;
            j = col - 1;
            while (i >= 0 && j >= 0)
            {
                if (nextRow == i && nextCol == j)
                {
                    return true;
                }
                i--;
                j--;
            }
            i = row - 1;
            j = col + 1;
            while (i >= 0 && j < n)
            {
                if (nextRow == i && nextCol == j)
                {
                    return true;
                }
                i--;
                j++;
            }
            return false;
        }

        private static bool CheckForR(int row, int col, int nextRow, int nextCol, int n)
        {
            for (int i = row + 1; i < n; i++)
            {
                if (nextRow == i && nextCol == col)
                {
                    return true;
                }
            }
            for (int i = 0; i < row; i++)
            {
                if (nextRow == i && nextCol == col)
                {
                    return true;
                }
            }
            for (int j = 0; j < col; j++)
            {
                if (row == nextRow && j == nextCol)
                {
                    return true;
                }
            }
            for (int j = col + 1; j < n; j++)
            {
                if (nextRow == row && nextCol == j)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckForK(int row, int col, int nextRow, int nextCol)
        {
            int[] rows = new int[] { 1, -1, 0, 0, -1, -1, 1, 1 };
            int[] cols = new int[] { 0, 0, 1, -1, -1, 1, -1, 1 };

            for (int i = 0; i < rows.Length; i++)
            {
                if (nextRow == row + rows[i] && nextCol == col + cols[i])
                {
                    return true;
                }
            }

            return false;
        }
        private static bool CheckForP(int row, int col, int nextRow, int nextCol)
        {
            return nextRow == row - 1;
        }

        private static bool IsOutOfBounds(int row, int col, int n)
        {
            return row < 0 || row >= n || col < 0 || col >= n;
        }
    }

}
