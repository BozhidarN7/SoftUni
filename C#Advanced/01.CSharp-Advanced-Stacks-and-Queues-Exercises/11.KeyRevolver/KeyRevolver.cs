using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int revolver = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligence = int.Parse(Console.ReadLine());
            int moneyEarned = intelligence;
            int currentShots = 0;
            while (bullets.Count != 0 && locks.Count != 0)
            {
                if (currentShots == revolver)
                {
                    Console.WriteLine("Reloading!");
                    currentShots = 0;
                }

                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();
                currentShots++;
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                moneyEarned -= bulletPrice;
            }
            if (bullets.Count != 0 && currentShots == revolver)
            {
                Console.WriteLine("Reloading!");
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
