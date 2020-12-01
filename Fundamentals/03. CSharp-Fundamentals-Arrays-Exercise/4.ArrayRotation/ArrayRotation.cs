using System;
using System.Linq;

namespace _4.ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotationNumber = int.Parse(Console.ReadLine());
            rotationNumber %= arr.Length;
         
            for (int i = rotationNumber; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            for (int i = 0; i < rotationNumber; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
