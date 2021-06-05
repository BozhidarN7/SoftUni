using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithRepetition
{
    class CombinationsWithRepetition
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }

            PrintCombinations(array, new int[k], 0, 0);

        }

        private static void PrintCombinations(int[] array, int[] vektor, int index, int boarder)
        {
            if (index == vektor.Length)
            {
                Console.WriteLine(string.Join(" ", vektor));
                return;
            }

            for (int i = boarder; i < array.Length; i++)
            {
                vektor[index] = array[i];
                PrintCombinations(array, vektor, index + 1, i);
            }
        }
    }
}
