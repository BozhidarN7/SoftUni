using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CombinationsWithoutRepetition
{
    class CombinationsWithoutRepetition
    {
        private static char[] elements;
        private static char[] combinations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            k = int.Parse(Console.ReadLine());
            combinations = new char[k];

            Vary(0, 0);
        }

        private static void Vary(int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = start; i <= elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    Vary(index + 1, i);
                }
            }
        }
    }
}

