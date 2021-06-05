using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ConectingCables
{
    class ConectingCables
    {
        private static int[] permutations;
        private static int[] defaultSequance;

        private static int[,] cableConnectionTable;

        static void Main(string[] args)
        {
            permutations = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            defaultSequance = new int[permutations.Length];
            for (int i = 0; i < defaultSequance.Length; i++)
            {
                defaultSequance[i] = i + 1;
            }

            cableConnectionTable = new int[defaultSequance.Length + 1, permutations.Length + 1];
            for (int i = 0; i < cableConnectionTable.GetLength(0); i++)
            {
                for (int j = 0; j < cableConnectionTable.GetLength(1); j++)
                {
                    cableConnectionTable[i, j] = -1;
                }
            }

            int maxConnections = ConnectCables(defaultSequance.Length, permutations.Length);
            Console.WriteLine($"Maximum pairs connected: {maxConnections}");
        }

        private static int ConnectCables(int sequanceIndex, int permutationIndex)
        {
            if (sequanceIndex <= 0 || permutationIndex <= 0)
            {
                return 0;
            }
            if (cableConnectionTable[sequanceIndex, permutationIndex] != -1)
            {
                return cableConnectionTable[sequanceIndex, permutationIndex];
            }

            if (defaultSequance[sequanceIndex - 1] == permutations[permutationIndex - 1])
            {
                cableConnectionTable[sequanceIndex, permutationIndex] = 1 + ConnectCables(sequanceIndex - 1, permutationIndex - 1);
            }
            else
            {
                int reduceDefaultSequance = ConnectCables(sequanceIndex - 1, permutationIndex);
                int reducePermutation = ConnectCables(sequanceIndex, permutationIndex - 1);

                cableConnectionTable[sequanceIndex, permutationIndex] = Math.Max(reduceDefaultSequance, reducePermutation);
            }

            return cableConnectionTable[sequanceIndex, permutationIndex];
        }
    }
}
