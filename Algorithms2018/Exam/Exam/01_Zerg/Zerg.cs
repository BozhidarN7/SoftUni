using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _01_Zerg
{
    class Zerg
    {
        private static BigInteger[,] matrix;
        private static BigInteger paths = 0;

        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            matrix = new BigInteger[rows, cols];

            int[] endPoint = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int endRow = endPoint[0];
            int endCol = endPoint[1];

            int numberOfEnemies = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEnemies; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int curretnRow = line[0];
                int currentCol = line[1];

                matrix[curretnRow, currentCol] = -1;
            }


            paths = FindAllPaths(endRow, endCol);
            Console.WriteLine(paths);
        }

        private static BigInteger FindAllPaths(int endRow, int endCol)
        {
            if (matrix[0, 0] == -1)
            {
                return 0;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == 0)
                {
                    matrix[i, 0] = 1;
                }

                else
                {
                    break;
                }
            }

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] == 0)
                {
                    matrix[0, i] = 1;
                }

                else
                {
                    break;
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                    {
                        continue;
                    }

                    if (matrix[i - 1, j] > 0)
                    {
                        matrix[i, j] = (matrix[i, j] + matrix[i - 1, j]);
                    }

                    if (matrix[i, j - 1] > 0)
                    {
                        matrix[i, j] = (matrix[i, j] + matrix[i, j - 1]);
                    }
                }
            }

            return (matrix[endRow, endCol] > 0) ?
                    matrix[endRow, endCol] : 0;
        }
    }
}
