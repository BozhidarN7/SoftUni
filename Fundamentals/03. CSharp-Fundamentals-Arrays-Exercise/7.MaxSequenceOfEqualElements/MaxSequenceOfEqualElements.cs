using System;
using System.Linq;

namespace _7.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int longest = 0;
            int startIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentLength = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        currentLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (longest < currentLength)
                {
                    longest = currentLength;
                    startIndex = i;
                }
            }

            for (int i = startIndex; i < startIndex + longest; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
