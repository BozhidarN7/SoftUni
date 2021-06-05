using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AreasInMatrix
{
    class AreasInMatrix
    {
        private static Dictionary<char, int> areas = new Dictionary<char, int>();

        private static char[][] matrix;
        private static bool[,] visited;

        private static int totalAreas = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                matrix[row] = new char[line.Length];

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];
                }
            }

            visited = new bool[rows, matrix[rows - 1].Length];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (visited[row, col] == false)
                    {
                        char currentLetter = matrix[row][col];
                        int colLength = matrix[row].Length;
                        DFS(row, col, currentLetter,colLength);

                        if (!areas.ContainsKey(currentLetter))
                        {
                            areas[currentLetter] = 1;
                        }
                        else
                        {
                            areas[currentLetter]++;
                        }

                        totalAreas++;
                    }

                }
            }

            Console.WriteLine($"Areas: {totalAreas}");

            foreach (var area in areas.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char letter,int colLength)
        {
            if (row < 0 || row >= matrix.Length || col < 0 || col >= colLength)
            {
                return;
            }

            if (matrix[row][col] != letter)
            {
                return;
            }

            if (!visited[row, col])
            {
                visited[row, col] = true;

                DFS(row + 1, col, letter, colLength);
                DFS(row - 1, col, letter, colLength);
                DFS(row, col + 1, letter, colLength);
                DFS(row, col - 1, letter, colLength);
            }
        }
    }
}
