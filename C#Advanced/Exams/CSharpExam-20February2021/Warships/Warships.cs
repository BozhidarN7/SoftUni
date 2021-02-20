using System;
using System.Linq;

namespace Warships
{
    class Warships
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[n, n];

            int playerOneShips = 0;
            int playerTwoShips = 0;

            for (int i = 0; i < n; i++)
            {
                string rowData = string.Join("", Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == '<')
                    {
                        playerOneShips++;
                    }
                    if (matrix[i, j] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            int totalShips = playerOneShips + playerTwoShips;
            int winner = -1;
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] tokens = coordinates[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = tokens[0];
                int col = tokens[1];

                if (IsOutOfBounds(row, col, n))
                {
                    continue;
                }

                if (matrix[row, col] == '<')
                {
                    matrix[row, col] = 'X';
                    playerOneShips--;
                }
                else if (matrix[row, col] == '>')
                {
                    matrix[row, col] = 'X';
                    playerTwoShips--;
                }
                else if (matrix[row, col] == '#')
                {
                    int[] rows = new int[] { 1, -1, 0, 0, 1, 1, -1, -1 };
                    int[] cols = new int[] { 0, 0, 1, -1, -1, 1, -1, 1 };

                    for (int j = 0; j < rows.Length; j++)
                    {
                        int nextRow = rows[j] + row;
                        int nextCol = cols[j] + col;

                        if (IsInBounds(nextRow, nextCol, n))
                        {
                            if (matrix[nextRow, nextCol] == '<')
                            {
                                playerOneShips--;
                            }
                            else if (matrix[nextRow, nextCol] == '>')
                            {
                                playerTwoShips--;
                            }
                            matrix[nextRow, nextCol] = 'X';
                        }
                    }
                    matrix[row, col] = 'X';
                }

                if (playerOneShips == 0)
                {
                    winner = 1;
                    break;
                }
                else if (playerTwoShips == 0)
                {
                    winner = 0;
                    break;
                }
            }

            if (winner == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - playerOneShips - playerTwoShips} ships have been sunk in the battle.");
            }
            else if (winner == 1)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - playerTwoShips - playerOneShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        private static bool IsInBounds(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static bool IsOutOfBounds(int row, int col, int n)
        {
            return row < 0 || col < 0 || row >= n || col >= n;
        }
    }
}
