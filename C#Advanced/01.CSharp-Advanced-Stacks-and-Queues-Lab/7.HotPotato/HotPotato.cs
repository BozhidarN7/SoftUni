using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            int currentMove = 1;
            while (players.Count != 1)
            {
                if (currentMove != n)
                {
                    string currentPlayer = players.Dequeue();
                    players.Enqueue(currentPlayer);
                    currentMove++;
                }
                else
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    currentMove = 1;
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
