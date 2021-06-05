using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArray
{
    class ReverseArray
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Reverse(array, array.Length - 1);
        }

        static void Reverse(int[] array, int index)
        {
            if (index < 0)
            {
                return;
            }

            Console.Write(array[index] + " ");
            Reverse(array, index - 1);
        }
    }
}
