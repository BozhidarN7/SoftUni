using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Towns
{
    class Towns
    {
        static void Main(string[] args)
        {
            int numberOfTowns = int.Parse(Console.ReadLine());

            int[] citizentPerTown = new int[numberOfTowns];

            for (int i = 0; i < numberOfTowns; i++)
            {
                int citizens = int.Parse(Console.ReadLine().Split(' ')[0]);
                citizentPerTown[i] = citizens;
            }

            int[] LISLength = new int[numberOfTowns];
            int maxLenLiS = 0;
            int lastIndex = -1;

            for (int i = 0; i < citizentPerTown.Length; i++)
            {
                LISLength[i] = 1;
                for (int j = 0; j <= i - 1; j++)
                {
                    if (citizentPerTown[j] < citizentPerTown[i] && LISLength[j] + 1 > LISLength[i])
                    {
                        LISLength[i] = 1 + LISLength[j];
                    }
                }
                if (LISLength[i] > maxLenLiS)
                {
                    maxLenLiS = LISLength[i];
                    lastIndex = i;
                }

            }

            int[] reversedTowns = citizentPerTown.Reverse().ToArray();

            int[] LDSLengths = new int[reversedTowns.Length];
            int maxLenLDS = 0;
            for (int i = 0; i < reversedTowns.Length; i++)
            {
                LDSLengths[i] = 1;
                for (int j = 0; j <= i - 1; j++)
                {
                    if (reversedTowns[j] < reversedTowns[i] && LDSLengths[j] + 1 > LDSLengths[i])
                    {
                        LDSLengths[i] = 1 + LDSLengths[j];
                    }
                }
                if (LDSLengths[i] > maxLenLDS)
                {
                    maxLenLDS = LDSLengths[i];
                }

            }

            int[] result = new int[LDSLengths.Length];
            LDSLengths = LDSLengths.Reverse().ToArray();
            for (int i = 0;  i < result.Length;  i++)
            {
                result[i] = LDSLengths[i] + LISLength[i];
            }

            Console.WriteLine(result.Max() - 1);
        }
    }
}
