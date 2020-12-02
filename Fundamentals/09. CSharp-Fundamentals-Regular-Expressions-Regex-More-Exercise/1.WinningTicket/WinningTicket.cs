using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Regex pattern = new Regex(@"@{6,}|\${6,}|#{6,}|\^{6,}");
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = tickets[i].Substring(0, 10);
                string secondHalf = tickets[i].Substring(10);
                Match firstMatch = pattern.Match(firstHalf);
                Match secondMatch = pattern.Match(secondHalf);
                if (firstMatch.Value.Length == 10 && secondMatch.Value.Length == 10)
                {
                    Console.WriteLine($"ticket \"{tickets[i]}\" - 10{firstMatch.Value[0]} Jackpot!");
                }
                else if (firstMatch.Success && secondMatch.Success && firstMatch.Value[0] == secondMatch.Value[0])
                {
                    Console.WriteLine($"ticket \"{ tickets[i]}\" - {Math.Min(firstMatch.Length,secondMatch.Length)}{firstMatch.Value[0]}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                }
            }
        }
    }
}
