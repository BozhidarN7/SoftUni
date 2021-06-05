using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        coins = coins.OrderByDescending(x => x).ToList();

        int coindIndex = 0;
        int currentSum = 0;

        while (coindIndex < coins.Count && currentSum != targetSum)
        {
            int currentCoinValue = coins[coindIndex];

            if (currentSum + currentCoinValue > targetSum)
            {
                coindIndex++;
                continue;
            }

            int remainingSum = targetSum - currentSum;
            int coinsToTake = remainingSum / currentCoinValue;

            if (coinsToTake > 0)
            {
                result[currentCoinValue] = coinsToTake;
                currentSum += coinsToTake * currentCoinValue;
            }
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}
