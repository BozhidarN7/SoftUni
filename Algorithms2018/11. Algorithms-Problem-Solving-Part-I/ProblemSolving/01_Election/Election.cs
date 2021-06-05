using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_Election
{
    class Election
    {
        static void Main(string[] args)
        {
            int totalSeats = int.Parse(Console.ReadLine());
            int numberOfParties = int.Parse(Console.ReadLine());

            int[] parties = new int[numberOfParties];

            for (int i = 0; i < numberOfParties; i++)
            {
                parties[i] = int.Parse(Console.ReadLine());
            }


            FindAllPossibleCombinations(totalSeats, parties);
        }

        private static void FindAllPossibleCombinations(int totalSeats, int[] parties)
        {
            BigInteger[] sums = new BigInteger[parties.Sum() + 1];
            sums[0] = 1;

            int maxSum = 0;

            foreach (var item in parties)
            {
                for (int i = maxSum; i >= 0; i--)
                {
                    if (sums[i] != 0)
                    {
                        sums[i + item] += sums[i];
                        maxSum = Math.Max(maxSum, i + item);
                    }
                }
            }

            BigInteger count = 0;
            for (int i = totalSeats; i <= maxSum; i++)
            {
                count += sums[i];
            }
            Console.WriteLine(count);
        }
    }
}
