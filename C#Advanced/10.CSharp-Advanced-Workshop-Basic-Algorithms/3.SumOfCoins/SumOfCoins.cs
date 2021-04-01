using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class SumOfCoins
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(": ");
            int[] coins = input[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            input = Console.ReadLine().Split(": ");
            long sum = long.Parse(input[1]);

            Array.Sort(coins,(a ,b) => -a.CompareTo(b));
            Dictionary<int, long> result = new Dictionary<int, long>();
            for (int i = 0; i < coins.Length; )
            {
                if (coins[i] <= sum)
                {
                    long coinsToTake = sum / coins[i];
                    sum -= coins[i] * coinsToTake;
                    if (!result.ContainsKey(coins[i]))
                    {
                        result.Add(coins[i], 0);
                    }
                    result[coins[i]]+= coinsToTake;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
            foreach((int coin, long times) in result)
            {
                Console.WriteLine($"{times} coin(s) with value {coin}");
            }
        }
    }
}
