using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MinimumEditDistance
{
    class MinimumEditDistance
    {
        static void Main(string[] args)
        {
            var costReplace = int.Parse(Console.ReadLine().Split(' ')[2]);
            var costInsert = int.Parse(Console.ReadLine().Split(' ')[2]);
            var costDelete = int.Parse(Console.ReadLine().Split(' ')[2]);

            var first = Console.ReadLine().Split(' ')[2];
            var second = Console.ReadLine().Split(' ')[2];

            var dp = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= second.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + costInsert;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + costDelete;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        var delete = dp[i - 1, j] + costDelete;
                        var insert = dp[i, j - 1] + costInsert;
                        var replace = dp[i - 1, j - 1] + costReplace;

                        dp[i, j] = Math.Min(insert, Math.Min(delete, replace));
                    }
                }
            }

            Console.WriteLine(dp[first.Length,second.Length]);
        }
    }
}


