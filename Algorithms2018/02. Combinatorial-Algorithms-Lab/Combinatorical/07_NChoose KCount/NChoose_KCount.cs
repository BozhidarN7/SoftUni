using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_NChoose_KCount
{
    class NChoose_KCount
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n, k));
        }

        private static decimal Binom(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }

            if (k > n - k)
            {
                k = n - k;
            }

            long c = 1;

            for (long i = 1; i <= k; i++)
            {
                c *= n--;
                c /= i;
            }

            return c;
        }
    }
}
