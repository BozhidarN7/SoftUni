using System;
using System.Linq;

namespace _5.TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool isTopInteger = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine(arr[arr.Length - 1]);
        }
    }
}
