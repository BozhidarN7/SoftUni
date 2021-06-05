using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationswithoutRepetition
{
    class CombinationswithoutRepetition
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            GenCombWithoutRep(array, new int[k], 0, 0);

        }

        private static void GenCombWithoutRep(int[] array, int[] vektor, int index, int boarder)
        {
            if (index == vektor.Length)
            {
                Console.WriteLine(string.Join(" ",vektor));
                return;
            }

            for (int i = boarder; i < array.Length; i++)
            {
                vektor[index] = array[i];
                GenCombWithoutRep(array, vektor, index + 1, i + 1);
            }
        }
    }
}
