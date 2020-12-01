using System;
using System.Linq;

namespace _9.CaminoFactory
{
    class CaminoFactory
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxSum = 0;
            int startIndex = 0;
            int longest = 0;
            int iteration = 1;
            int bestIteration = 1;
            int[] bestDNA = new int[n];
            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                int[] arr = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentSum = arr.Sum();
                int currentLongest = 0;
                int currentIndex = 0;

                for (int i = 0; i < n; i++)
                {
                    if (arr[i] == 1)
                    {
                        currentLongest++;

                        if (longest < currentLongest)
                        {
                            longest = currentLongest;
                            startIndex = currentIndex;
                            maxSum = currentSum;
                            bestDNA = arr;
                            bestIteration = iteration;
                        }
                        if (longest == currentLongest && startIndex > currentIndex)
                        {
                            longest = currentLongest;
                            startIndex = currentIndex;
                            maxSum = currentSum;
                            bestDNA = arr;
                            bestIteration = iteration;
                        }
                        else if (longest == currentLongest && maxSum < currentSum)
                        {
                            longest = currentLongest;
                            startIndex = currentIndex;
                            maxSum = currentSum;
                            bestDNA = arr;
                            bestIteration = iteration;
                        }
                    }
                    else
                    {
                        currentLongest = 0;
                        currentIndex = i + 1;
                    }
                }
                iteration++;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIteration} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}
