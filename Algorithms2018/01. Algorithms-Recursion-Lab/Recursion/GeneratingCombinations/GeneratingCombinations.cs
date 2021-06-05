using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratingCombinations
{
    class GeneratingCombinations
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            GenComb(elements, new int[k], 0, 0);
        }

        private static void GenComb(int[] elements, int[] vektor, int index, int boarder)
        {
            if (index > vektor.Length - 1)
            {
                Console.WriteLine(string.Join(" ", vektor));
                return;
            }

            for (int i = boarder; i < elements.Length; i++)
            {
                vektor[index] = elements[i];
                GenComb(elements, vektor, index + 1, i + 1);
            }
        }
    }
}
