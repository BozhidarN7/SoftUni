using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_VariationsWithoutRepetitions
{
    class VariationsWithoutRepetitions
    {
        private static char[] elements;
        private static char[] variations;
        private static bool[] used;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            used = new bool[elements.Length];

            k = int.Parse(Console.ReadLine());
            variations = new char[k];

            Vary(0, 0);
        }

        private static void Vary(int index, int boarder)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Vary(index + 1, i + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
