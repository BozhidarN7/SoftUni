using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        private static int[] sequance;
        private static int[] lengths;
        private static int[] previous;

        private static List<int> result = new List<int>();

        static void Main(string[] args)
        {
            sequance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            lengths = new int[sequance.Length];
            previous = new int[sequance.Length];

            FindLongestSubsequance();
            Console.WriteLine(string.Join(" ",result));
        }

        private static void FindLongestSubsequance()
        {
            int maxLen = 0;
            int lastIndex = 0;

            for (int i = 0; i < sequance.Length; i++)
            {
                lengths[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequance[i] > sequance[j] && lengths[j] + 1 > lengths[i])
                    {
                        lengths[i] = lengths[i] + 1;
                        previous[i] = j;

                    }
                }

                if (lengths[i] > maxLen)
                {
                    maxLen = lengths[i];
                    lastIndex = i;
                }
            }

            RecoverTheSequance(lastIndex);
        }

        private static void RecoverTheSequance(int index)
        {
            while (index >= 0)
            {
                result.Add(sequance[index]);
                index = previous[index];
            }

            result.Reverse();
        }
    }
}
