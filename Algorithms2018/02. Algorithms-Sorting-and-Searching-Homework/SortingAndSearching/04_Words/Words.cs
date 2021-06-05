using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Words
{
    class Words
    {
        private static char[] symbols;
        private static int count = 0;

        static void Main(string[] args)
        {
            symbols = Console.ReadLine().ToCharArray();

            if (Optimize())
            {
                return;
            }
            Array.Sort(symbols);
            PermuteRep(0, symbols.Length - 1);
            //GeneratePermutations(0);
            Console.WriteLine(count);
        }

        private static bool Optimize()
        {
            HashSet<char> uniqueElements = new HashSet<char>();

            foreach (var symbol in symbols)
            {
                uniqueElements.Add(symbol);
            }

            if (uniqueElements.Count == symbols.Length)
            {
                Console.WriteLine(Fact(uniqueElements.Count));
                return true;
            }

            return false;
        }

        private static int Fact(int n)
        {
            int result = 1;
            for (int i = 2; i <=n; i++)
            {
                result = result * i;
            }

            return result;
        }

        /*private static void GeneratePermutations(int index)
        {
            if (index >= symbols.Length)
            {
                if (!CheckForEaqualCharacters())
                {
                    //Console.WriteLine(string.Join(" ",symbols));
                    count++;
                }
            }
            else
            {
                HashSet<char> swapped = new HashSet<char>();
                for (int i = index; i < symbols.Length; i++)
                {
                    if (!swapped.Contains(symbols[i]))
                    {
                        Swap(index, i);
                        GeneratePermutations(index + 1);
                        Swap(index, i);
                        swapped.Add(symbols[i]);
                    }
                }
            }
        }
        */
        private static bool CheckForEaqualCharacters()
        {
            for (int i = 0; i < symbols.Length - 1; i++)
            {
                if (symbols[i] == symbols[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
        
        private static void Swap(ref int first,ref int second)
        {
            char temp = symbols[first];
            symbols[first] = symbols[second];
            symbols[second] = temp;
        }

        private static void PermuteRep(int start, int end)
        {
            if (!CheckForEaqualCharacters())
            {
                count++;
            }
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (symbols[left] != symbols[right])
                    {
                        Swap(ref left, ref right);
                        PermuteRep(left + 1, end);
                    }
                var firstElement = symbols[left];
                for (int i = left; i <= end - 1; i++)
                    symbols[i] = symbols[i + 1];
                symbols[end] = firstElement;
            }
        }

    }
}
