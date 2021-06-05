using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KnightsTour
{
    class KnightsTour
    {
        private const int MaxMoves = 8;

        private static int[] moveRow = new int[] { 1, -1, 1, -1, 2, 2, -2, -2 };
        private static int[] moveCol = new int[] { 2, 2, -2, -2, 1, -1, 1, -1 };

        private static int size;
        private static int row;
        private static int col;

        private static int[,] chessBoard;
        private static int currentValue;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            chessBoard = new int[size, size];

            FindPath();
            PrintPath();
        }

        private static void FindPath()
        {
            row = 0;
            col = 0;
            chessBoard[0, 0] = 1;
            currentValue = 1;

            int boardArea = size * size;

            while (currentValue < boardArea)
            {
                int min = MaxMoves + 1;
                int choose = 0;

                for (int i = 0; i < MaxMoves; i++)
                {
                    int temp = CountMoves(row + moveRow[i], col + moveCol[i]);
                    if (temp < min)
                    {
                        min = temp;
                        choose = i;
                    }
                }

                row += moveRow[choose];
                col += moveCol[choose];
                chessBoard[row, col] = ++currentValue;
            }
        }
        private static int CountMoves(int x, int y)
        {
            int count = 0;
            if (x < 0 || y < 0 || x >= size || y >= size || chessBoard[x, y] != 0)
            {
                return MaxMoves + 1;
            }

            for (int i = 0; i < MaxMoves; i++)
            {
                int currentRow = x + moveRow[i];
                int currentCol = y + moveCol[i];
                if (currentRow >= 0 && currentCol >= 0 && currentRow < size && currentCol < size && chessBoard[currentRow, currentCol] == 0)
                {
                    count++;
                }
            }
            return count;
        }

        private static void PrintPath()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(chessBoard[i, j].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }
    }
}
