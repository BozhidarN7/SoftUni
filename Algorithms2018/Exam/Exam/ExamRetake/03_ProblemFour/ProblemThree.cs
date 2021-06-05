using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ProblemFour
{
    class ProblemThree
    {
        private static int shirts;
        private static int girls;
        private static string skirts;
        private static string result;

        static void Main(string[] args)
        {
            shirts = int.Parse(Console.ReadLine());
            skirts = Console.ReadLine();
            girls = int.Parse(Console.ReadLine());

            GenerateAll(0, 0, 0);
        }

        private static void GenerateAll(int shirtsIndex, int girlsIndex, int skirtsIndex)
        {
            if (girlsIndex == girls)
            {
                // Print
                return;
            }

            for (int i = 0; i < shirts - 1; i++)
            {
                if (girlsIndex == 0)
                {
                    result = i.ToString() + skirts[skirtsIndex].ToString();
                }
                else
                {
                    result += "-";
                    result += i.ToString() + skirts[skirtsIndex].ToString();
                }
            }
        }
    }
}
