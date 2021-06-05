using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Searching
{
    class BinnarySearch
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(IndexOf(array,number));
        }

        public static int IndexOf(int[] array, int number)
        {
            int lo = 0;
            int hi = array.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (number < array[mid])
                {
                    hi = mid - 1;
                }
                else if (number > array[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
