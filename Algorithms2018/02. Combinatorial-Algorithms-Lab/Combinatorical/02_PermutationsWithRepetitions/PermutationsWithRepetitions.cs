using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_PermutationsWithRepetitions
{
    class PermutationsWithRepetitions
    {
        private static char[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();


            PermuteWithRepetition(0);
        }

        private static void PermuteWithRepetition(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ",elements));
            }
            else
            {
                HashSet<char> swapped = new HashSet<char>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        PermuteWithRepetition(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }

        }

        private static void Swap(int first, int second)
        {
            char temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
