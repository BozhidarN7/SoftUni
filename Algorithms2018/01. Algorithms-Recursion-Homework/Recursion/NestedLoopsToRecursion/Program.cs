using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoopsToRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SimulateNestedLoops(n, 0, new int[n]);
        }

        private static void SimulateNestedLoops(int n, int index, int[] array)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                array[index] = i;
                SimulateNestedLoops(n, index + 1, array);
            }
        }
    }
}
