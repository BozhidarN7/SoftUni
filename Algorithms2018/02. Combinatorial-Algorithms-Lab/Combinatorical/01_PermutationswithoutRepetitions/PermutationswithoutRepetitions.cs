using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_PermutationswithoutRepetitions
{
    class PermutationswithoutRepetitions
    {
        private static char[] elemetns;
        //private static bool[] used;
        //private static char[] permutation;

        static void Main(string[] args)
        {
            elemetns = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            //used = new bool[elemetns.Length];
            //permutation = new char[elemetns.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elemetns.Length)
            {
                Console.WriteLine(string.Join(" ",elemetns));
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elemetns.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elemetns[first];
            elemetns[first] = elemetns[second];
            elemetns[second] = temp;
        }
    }
}

   
