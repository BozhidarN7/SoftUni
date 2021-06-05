using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensPuzzle
{
    class Program
    {
        private const int Size = 8;
        private static bool[,] chessBoard = new bool[Size, Size];

        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedcols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attacekdRightDiagonals= new HashSet<int>();

        private static int numberOfSolutionsFound = 0;

        static void Main(string[] args)
        {
            PlaceQueens(0);
            //Console.WriteLine(numberOfSolutionsFound);
        }

        private static void PlaceQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row,col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PlaceQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }

        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedcols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attacekdRightDiagonals.Remove(col + row);
            chessBoard[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedcols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attacekdRightDiagonals.Add(row + col);
            chessBoard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied = attackedRows.Contains(row)||
                attackedcols.Contains(col)||
                attackedLeftDiagonals.Contains(col - row)||
                attacekdRightDiagonals.Contains(row + col);

            return !positionOccupied;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessBoard[row,col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            numberOfSolutionsFound++;
        }
    }
}
