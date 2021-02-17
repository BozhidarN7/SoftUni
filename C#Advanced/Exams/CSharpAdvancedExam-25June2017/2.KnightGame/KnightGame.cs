using System;

namespace _2.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int knightsToRemove = 0;
            while (true)
            {
                int maxAttacker = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] != 'K')
                        {
                            continue;
                        }
                        int count = HasAdjecentKnights(matrix, i, j, n);

                        if (count > maxAttacker)
                        {
                            maxAttacker = count;
                            knightRow = i;
                            knightCol = j;
                        }
                    }
                }
                if (maxAttacker == 0)
                {
                    break;
                }
                matrix[knightRow, knightCol] = 'O';
                knightsToRemove++;
            }
            Console.WriteLine(knightsToRemove);
        }
        private static int HasAdjecentKnights(char[,] matrix, int row, int col, int n)
        {
            int count = 0;
            int[] rows = new int[] { 2, 2, -2, -2, -1, -1, 1, 1 };
            int[] cols = new int[] { 1, -1, 1, -1, 2, -2, 2, -2 };

            for (int i = 0; i < rows.Length; i++)
            {
                int nextRow = row + rows[i];
                int nextCol = col + cols[i];

                if (IsValid(nextRow, nextCol, n) && matrix[nextRow, nextCol] == 'K')
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsValid(int nextRow, int nextCol, int n)
        {
            return nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n;
        }
    }
}
