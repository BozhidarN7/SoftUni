using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DistanceInLabyrinth
{
    class Maze
    {
        //Problem 7.	* Distance in Labyrinth
        public class Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Distance { get; set; }

            public Cell(int row, int col, int distance)
            {
                this.Row = row;
                this.Col = col;
                this.Distance = distance;
            }
        }

        private Cell startCell = null;
        private string[,] maze;
        private string[,] encirclingMaze;
        private int size;
        private int row;
        private int col;

        static void Main(string[] args)
        {
            Maze maze = new Maze();
            maze.CreateMaze();
            maze.FindDistances();
            maze.FillEmtyCells();
            Console.WriteLine();
            maze.PrintMaze();
        }

        private void FillEmtyCells()
        {
            encirclingMaze[row, col] = "*";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (encirclingMaze[i, j] == "0" && encirclingMaze[i, j] != "*")
                    {
                        encirclingMaze[i, j] = "u";
                    }
                }
            }
        }

        private void PrintMaze()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(encirclingMaze[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void CreateMaze()
        {
            size = int.Parse(Console.ReadLine());
            maze = new string[size, size];
            encirclingMaze = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    maze[i, j] = Convert.ToString(input[j]);
                    encirclingMaze[i, j] = Convert.ToString(input[j]);
                    if (maze[i, j] == "*")
                    {
                        this.startCell = new Cell(i, j, 0);
                        row = i;
                        col = j;
                    }
                }
            }
        }

        private void FindDistances()
        {
            Queue<Cell> visitedCells = new Queue<Cell>();
            VisitCell(visitedCells, this.startCell.Row, this.startCell.Col, 0);

            while (visitedCells.Count > 0)
            {
                Cell currentCell = visitedCells.Dequeue();
                int row = currentCell.Row;
                int col = currentCell.Col;
                int distance = currentCell.Distance;

                if (col != size - 1)
                {
                    VisitCell(visitedCells, row, col + 1, distance + 1);
                }
                if (col != 0)
                {
                    VisitCell(visitedCells, row, col - 1, distance + 1);
                }
                if (row != size - 1)
                {
                    VisitCell(visitedCells, row + 1, col, distance + 1);
                }
                if (row != 0)
                {
                    VisitCell(visitedCells, row - 1, col, distance + 1);
                }
            }
        }

        private void VisitCell(Queue<Cell> visitedCells, int row, int col, int distance)
        {
            if (this.maze[row, col] != "x")
            {
                this.maze[row, col] = "x";
                if (maze[row, col] != "*")
                {
                    this.encirclingMaze[row, col] = Convert.ToString(distance);
                }
                Cell cell = new Cell(row, col, distance);
                visitedCells.Enqueue(cell);
            }
        }
    }
}