using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _3.GreedyTimes
{
    class GreedyTimes
    {
        static void Main(string[] args)
        {
            BigInteger capcity = BigInteger.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            BigInteger totalGold = new BigInteger();
            input.Select((x, i) =>
            {
                if (x.ToLower() == "gold")
                {
                    return new KeyValuePair<string, BigInteger>(x, BigInteger.Parse(input[i + 1]));
                }
                return new KeyValuePair<string, BigInteger>();
            })
               .Where(x => x.Key != null)
               .OrderByDescending(x => x.Value)
               .ToList()
               .ForEach(x =>
               {
                   if (totalGold + x.Value <= capcity)
                   {
                       totalGold += x.Value;
                   }
               });

            capcity -= totalGold;
            BigInteger totalGems = 0;
            Dictionary<string, BigInteger> gems = new Dictionary<string, BigInteger>();
            input.Select((x, i) =>
            {
                if (x.ToLower().Contains("gem"))
                {
                    return new KeyValuePair<string, BigInteger>(x, BigInteger.Parse(input[i + 1]));
                }
                return new KeyValuePair<string, BigInteger>();
            })
                .Where(x => x.Key != null)
                .OrderByDescending(x => x.Value)
                .ToList()
                .ForEach(x =>
                {
                    if (totalGems + x.Value <= capcity && totalGems + x.Value <= totalGold)
                    {
                        if (!gems.ContainsKey(x.Key))
                        {
                            gems.Add(x.Key, 0);
                        }
                        gems[x.Key] += x.Value;
                        totalGems += x.Value;
                    }
                });

            capcity -= totalGems;
            BigInteger totalCash = 0;
            Dictionary<string, BigInteger> cashes = new Dictionary<string, BigInteger>();
            input.Select((x, i) =>
             {
                 if (x.Length == 3)
                 {
                     return new KeyValuePair<string, BigInteger>(x, BigInteger.Parse(input[i + 1]));
                 }
                 return new KeyValuePair<string, BigInteger>();
             })
                 .Where(x => x.Key != null)
                 .OrderByDescending(x => x.Value)
                 .ToList()
                 .ForEach(x =>
                 {
                     if (totalCash + x.Value <= capcity && totalCash + x.Value <= totalGems)
                     {
                         if (!cashes.ContainsKey(x.Key))
                         {
                             cashes.Add(x.Key, 0);
                         }
                         cashes[x.Key] += x.Value;
                         totalCash += x.Value;
                     }
                 });

            Console.WriteLine($"<Gold> ${totalGold}");
            Console.WriteLine($"##Gold - {totalGold}");

            if (totalGems > 0)
            {
                Console.WriteLine($"<Gem> ${totalGems}");
                foreach (KeyValuePair<string,BigInteger> pair in gems.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{pair.Key} - {pair.Value}");
                }
            }
            if (totalCash > 0)
            {
                Console.WriteLine($"<Cash> ${totalCash}");
                foreach (KeyValuePair<string, BigInteger> pair in cashes.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{pair.Key} - {pair.Value}");
                }
            }
        }


    }
}
