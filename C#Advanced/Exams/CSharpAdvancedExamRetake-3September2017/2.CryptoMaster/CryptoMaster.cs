using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.CryptoMaster
{
    class CryptoMaster
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxCount = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j <= numbers.Length; j++)
                {
                    int currentMax = 1;
                    int previous = i;
                    int index = (i + j) % numbers.Length;

                    while (numbers[i] != numbers[index])
                    {
                        if (numbers[index] > numbers[previous])
                        {
                            currentMax++;
                        }
                        else
                        {
                            break;
                        }
                        previous = index;
                        index = (index + j) % numbers.Length;
                    }

                    if ( maxCount < currentMax)
                    {
                        maxCount = currentMax;
                    }
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
