using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RodCutting
{
    class RodCutting
    {
        private static int[] prices;
        private static int[] bestPrices;
        private static int[] bestCombo;

        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bestPrices = new int[prices.Length];
            bestCombo = new int[prices.Length];

            int length = int.Parse(Console.ReadLine());

            Console.WriteLine(CutTheRod(length));
            ReconstructSolution(length) ;
        }

        private static int CutTheRod(int length)
        {
            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            if (length == 0)
            {
                return 0;
            }
            else
            {
                int max = 0;
                int wholePart = length;

                for (int i = 1; i <= length; i++)
                {
                    int currentMax = Math.Max(prices[i], prices[i] + CutTheRod(length - i));
                    if (currentMax > max)
                    {
                        wholePart = i;
                        max = currentMax;
                    }
                }

                bestCombo[length] = wholePart;
                bestPrices[length] = max;
                return bestPrices[length];
            }
        }

        private static void ReconstructSolution(int length)
        {
            while (length != 0)
            {
                Console.Write(bestCombo[length] + " ");
                length = length - bestCombo[length];
            }
            Console.WriteLine();
        }
    }
}
