using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPathInLabyrinth
{
    class FindAllPathInLabyrinth
    {
        private static int rows;
        private static int cols;
        private static char[,] maze;
        private static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            maze = new char[rows, cols];
            FillMaze(maze);
            FindAllPaths(0, 0, 'S');
        }

        private static void FindAllPaths(int row, int col, char direction)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return;
            }

            path.Add(direction);

            if (maze[row, col] == 'e')
            {
                PrintPath();
            }

            if (maze[row,col] == '-')
            {
                maze[row, col] = 's';

                FindAllPaths(row + 1, col, 'D');
                FindAllPaths(row - 1, col, 'U');
                FindAllPaths(row, col + 1, 'R');
                FindAllPaths(row, col - 1, 'L');

                maze[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            for (int i = 1; i < path.Count; i++)
            {
                Console.Write(path[i]);
            }
            Console.WriteLine();
        }

        private static void FillMaze(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    maze[row, col] = line[col];
                }
            }
        }
    }
}
