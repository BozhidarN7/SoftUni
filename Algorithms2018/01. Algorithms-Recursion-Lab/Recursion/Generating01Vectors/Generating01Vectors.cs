using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating01Vectors
{
    class Generating01Vectors
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Gen01(array, 0);
        }

        private static void Gen01(int[] array, int index)
        {
            if (index > array.Length - 1)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                Gen01(array, index + 1);
            }
        }
    }
}
