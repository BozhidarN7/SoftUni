using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_VariationsWithRepetition
{
    class VariationsWithRepetition
    {
        private static char[] elements;
        private static char[] variations;
        private static int k;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            k = int.Parse(Console.ReadLine());
            variations = new char[k];

            Vary(0);
        }

        private static void Vary(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    variations[index] = elements[i];
                    Vary(index + 1);

                }
            }
        }
    }
}
