using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            char[,] matrix = new char[rows, cols];
            int row = 0;
            int col = 0;
            Queue<KeyValuePair<int, int>> bunnies = new Queue<KeyValuePair<int, int>>();
            for (int i = 0; i < rows; i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == 'P')
                    {
                        row = i;
                        col = j;
                    }
                    if (matrix[i, j] == 'B')
                    {
                        bunnies.Enqueue(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            string moves = Console.ReadLine();
            bool hasWon = true;
            for (int m = 0; m < moves.Length; m++)
            {
                char move = moves[m];

                if (move == 'U')
                {
                    if (IsOutOfMatrix(row - 1, col, rows, cols))
                    {
                        matrix[row, col] = matrix[row, col] == 'P' ? '.' : matrix[row, col];
                        SpreadBunnies(matrix, ref bunnies, rows, cols);
                        row--;
                        break;
                    }
                    matrix[row, col] = '.';
                    if (matrix[row - 1, col] != 'B')
                    {
                        matrix[row - 1, col] = 'P';
                    }
                    if (!MovePlayer(matrix, ref bunnies, row - 1, col, rows, cols))
                    {
                        hasWon = false;
                        row--;
                        break;
                    };
                    row--;
                }
                else if (move == 'D')
                {
                    if (IsOutOfMatrix(row + 1, col, rows, cols))
                    {
                        matrix[row, col] = matrix[row, col] == 'P' ? '.' : matrix[row, col];
                        SpreadBunnies(matrix, ref bunnies, rows, cols);
                        row++;
                        break;
                    }
                    matrix[row, col] = '.';
                    if (matrix[row + 1, col] != 'B')
                    {
                        matrix[row + 1, col] = 'P';
                    }
                    if (!MovePlayer(matrix, ref bunnies, row + 1, col, rows, cols))
                    {
                        hasWon = false;
                        row++;
                        break;
                    };
                    row++;
                }
                else if (move == 'L')
                {
                    if (IsOutOfMatrix(row, col - 1, rows, cols))
                    {
                        matrix[row, col] = matrix[row, col] == 'P' ? '.' : matrix[row, col];
                        SpreadBunnies(matrix, ref bunnies, rows, cols);
                        col--;
                        break;
                    }
                    matrix[row, col] = '.';
                    if (matrix[row, col - 1] != 'B')
                    {
                        matrix[row, col - 1] = 'P';
                    }

                    if (!MovePlayer(matrix, ref bunnies, row, col - 1, rows, cols))
                    {
                        hasWon = false;
                        col--;
                        break;
                    };
                    col--;
                }
                else if (move == 'R')
                {
                    if (IsOutOfMatrix(row, col + 1, rows, cols))
                    {
                        matrix[row, col] = matrix[row, col] == 'P' ? '.' : matrix[row, col];
                        SpreadBunnies(matrix, ref bunnies, rows, cols);
                        col++;
                        break;
                    }
                    matrix[row, col] = '.';
                    if (matrix[row, col + 1] != 'B')
                    {
                        matrix[row, col + 1] = 'P';
                    }
                    if (!MovePlayer(matrix, ref bunnies, row, col + 1, rows, cols))
                    {
                        hasWon = false;
                        col++;
                        break;
                    };
                    col++;
                }
            }

            PrintMatrix(matrix, rows, cols);
            if (hasWon)
            {
                LastMove(moves, ref row, ref col);
                Console.WriteLine($"won: {row} {col}");
            }
            else
            {
                Console.WriteLine($"dead: {row} {col}");
            }
        }

        private static bool MovePlayer(char[,] matrix, ref Queue<KeyValuePair<int, int>> bunnies, int row, int col, int rows, int cols)
        {
            if (IsOutOfMatrix(row, col, rows, cols))
            {
                SpreadBunnies(matrix, ref bunnies, rows, cols);
                return true;
            }
            if (IsValid(row, col, rows, cols) && matrix[row, col] == 'B')
            {
                SpreadBunnies(matrix, ref bunnies, rows, cols);
                return false;
            }
            bool playerCatched = SpreadBunnies(matrix, ref bunnies, rows, cols);
            if (playerCatched)
            {
                return false;
            }
            return true;
        }
        private static bool SpreadBunnies(char[,] matrix, ref Queue<KeyValuePair<int, int>> bunnies, int rows, int cols)
        {
            Queue<KeyValuePair<int, int>> newBunnies = new Queue<KeyValuePair<int, int>>();
            bool playerCatched = false;
            while (bunnies.Count != 0)
            {
                KeyValuePair<int, int> bunny = bunnies.Dequeue();
                int row = bunny.Key;
                int col = bunny.Value;

                int[] rowsArr = { 1, -1, 0, 0 };
                int[] colsArr = { 0, 0, 1, -1 };

                for (int i = 0; i < rowsArr.Length; i++)
                {
                    int nextRow = row + rowsArr[i];
                    int nextCol = col + colsArr[i];

                    if (IsValid(nextRow, nextCol, rows, cols) && matrix[nextRow, nextCol] != 'B')
                    {
                        if (matrix[nextRow, nextCol] == 'P') playerCatched = true;
                        matrix[nextRow, nextCol] = 'B';
                        newBunnies.Enqueue(new KeyValuePair<int, int>(nextRow, nextCol));
                    }
                }
            }

            bunnies = newBunnies;
            if (playerCatched)
            {
                return true;
            }
            return false;
        }
        private static void LastMove(string moves, ref int row, ref int col)
        {
            if (moves[moves.Length - 1] == 'U')
            {
                row++;
            }
            else if (moves[moves.Length - 1] == 'D')
            {
                row--;
            }
            else if (moves[moves.Length - 1] == 'L')
            {
                col++;
            }
            else if (moves[moves.Length - 1] == 'R')
            {
                col--;
            }
        }
        private static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsValid(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        private static bool IsOutOfMatrix(int row, int col, int rows, int cols)
        {
            return row < 0 || row == rows || col < 0 || col == cols;
        }
    }
}
