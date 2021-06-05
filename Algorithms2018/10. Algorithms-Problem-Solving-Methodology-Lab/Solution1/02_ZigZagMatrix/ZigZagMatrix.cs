using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ZigZagMatrix
{
    class ZigZagMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }

            int[,] maxPaths = new int[rows, cols];
            int[,] previousRowIndex = new int[rows, cols];

            for (int i = 1; i < rows; i++)
            {
                maxPaths[i, 0] = matrix[i][0];
            }

            for (int col = 1; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int previousMax = 0;

                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < rows; i++)
                        {
                            if (maxPaths[i, col - 1] + matrix[row][col] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1] + matrix[row][col];
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row - 1; i++)
                        {
                            if (maxPaths[i, col - 1] + matrix[row][col] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1] + matrix[row][col];
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }
                    maxPaths[row, col] = previousMax + matrix[row][col];
                }
            }

            int currentRowIndex = GetLastRowIndex(maxPaths, cols);

            var path = RecoverPath(cols, matrix, currentRowIndex, previousRowIndex);
            Console.WriteLine($"{path.Sum()} = {string.Join(" + ", path)}");
        }

        private static List<int> RecoverPath(int cols, int[][] matrix, int currentRowIndex, int[,] previousRowIndex)
        {
            List<int> path = new List<int>();
            int colIndex = cols - 1;

            while (colIndex >= 0)
            {
                path.Add(matrix[currentRowIndex][colIndex]);
                currentRowIndex = previousRowIndex[currentRowIndex, colIndex];
                colIndex--;
            }
            path.Reverse();

            return path;
        }

        private static int GetLastRowIndex(int[,] maxPaths, int cols)
        {
            int currentRowIndex = -1;
            int globalMax = 0;
            for (int row = 0; row < maxPaths.GetLength(0); row++)
            {
                if (maxPaths[row, cols - 1] > globalMax)
                {
                    globalMax = maxPaths[row, cols - 1];
                    currentRowIndex = row;
                }
            }
            return currentRowIndex;
        }
    }
}
