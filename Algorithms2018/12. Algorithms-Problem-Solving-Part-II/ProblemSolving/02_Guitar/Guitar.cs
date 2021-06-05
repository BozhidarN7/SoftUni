using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Guitar
{
    class Guitar
    {
        static void Main(string[] args)
        {
            int[] listOfValumes = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int defaultValume = int.Parse(Console.ReadLine());
            int maxValume = int.Parse(Console.ReadLine());

            int[,] matrix = new int[listOfValumes.Length + 1, maxValume + 1];
            matrix[0, defaultValume] = 1;

            for (int row = 1; row <= listOfValumes.Length; row++)
            {
                for (int col = 0; col <= maxValume; col++)
                {
                    if (matrix[row - 1, col] == 1)
                    {
                        int above = col + listOfValumes[row - 1];
                        int below = col - listOfValumes[row - 1];

                        if (Check(above, maxValume))
                        {
                            matrix[row, above] = 1;
                        }

                        if (Check(below, maxValume))
                        {
                            matrix[row, below] = 1;
                        }
                    }
                }
            }

            bool hasSolution = false;
            for (int row = matrix.GetLength(0) - 1; row < matrix.GetLength(0); row++)
            {
                for (int col = maxValume; col >= 0; col--)
                {
                    if (matrix[row, col] == 1)
                    {
                        hasSolution = true;
                        Console.WriteLine(col);
                        break;
                    }
                }
            }

            if (!hasSolution)
            {
                Console.WriteLine(-1);
            }
        }

        private static bool Check(int valume, int maxValume)
        {
            if (valume <= maxValume && valume >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
