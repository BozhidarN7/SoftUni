using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GroupPermutations
{
    class GroupPermutations
    {
        private static BigInteger count = 0;
        private static char[] letters;

        private static Dictionary<char, int> dict = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            letters = Console.ReadLine().ToCharArray();

            foreach (var item in letters)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 1;
                }
                else
                {
                    dict[item]++;
                }
            }

            BigInteger sum = 1;

            foreach (var item in dict)
            {
                sum = sum * CalculateFact(item.Value);
            }

            count = CalculateFact(letters.Length) / sum;

            //Permute(0);

            Console.WriteLine(count);
        }

        private static BigInteger CalculateFact(int number)
        {
            BigInteger fact = number;
            for (int i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }

            return fact;
        }

        private static void Permute(int index)
        {
            if (index >= letters.Length)
            {
                count++;
            }
            else
            {
                HashSet<char> swapped = new HashSet<char>();
                for (int i = index; i < letters.Length; i++)
                {
                    if (!swapped.Contains(letters[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(letters[i]);
                    }
                }
            }
        }
        private static void Swap(int first, int second)
        {
            char temp = letters[first];
            letters[first] = letters[second];
            letters[second] = temp;
        }
    }
}