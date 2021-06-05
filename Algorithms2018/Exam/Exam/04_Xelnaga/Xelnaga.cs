using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04_Xelnaga
{
    class Xelnaga
    {
        private static Dictionary<int, int> species = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BigInteger sum = 0;

            for (int i = 0; i < sequance.Length - 1; i++)
            {
                int current = sequance[i];

                if (!species.ContainsKey(current))
                {
                    sum += current + 1;

                    species[current] = current + 1;
                }

                species[current]--;

                if (species[current] == 0)
                {
                    species.Remove(current);
                }

            }

            Console.WriteLine(sum);
        }
    }
}
