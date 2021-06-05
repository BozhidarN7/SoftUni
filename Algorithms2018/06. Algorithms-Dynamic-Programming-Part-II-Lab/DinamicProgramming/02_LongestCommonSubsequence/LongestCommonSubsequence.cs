using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LongestCommonSubsequence
{
    class LongestCommonSubsequence
    {
        static void Main(string[] args)
        {
            string firstSequance = Console.ReadLine();
            string secondSequance = Console.ReadLine();

            int[,] lcsTable = new int[firstSequance.Length + 1, secondSequance.Length + 1];

            FindLCS(firstSequance, secondSequance, lcsTable);

            Console.WriteLine(lcsTable[firstSequance.Length, secondSequance.Length]);
        }

        private static void FindLCS(string firstSequance, string secondSequance, int[,] lcsTable)
        {
            for (int row = 1; row <= firstSequance.Length; row++)
            {
                for (int col = 1; col <= secondSequance.Length; col++)
                {
                    int up = lcsTable[row - 1, col];
                    int left = lcsTable[row, col - 1];

                    int result = Math.Max(up, left);

                    if (firstSequance[row - 1] == secondSequance[col - 1])
                    {
                        result = Math.Max(1 + lcsTable[row - 1, col - 1], result);
                    }

                    lcsTable[row, col] = result;
                }
            }
        }
    }
}
