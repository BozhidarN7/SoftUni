using System;

namespace _4._MorseCodeUpgraded
{
    class MorseCodeUpgraded
    {
        static void Main(string[] args)
        {
            string[] message = Console.ReadLine().Split('|');
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                int[] occ = new int[2];
                int bonus = 0;
                int equalSec = 1;
                for (int j = 0; j < message[i].Length - 1; j++)
                {
                    occ[message[i][j] - '0']++;
                    if (message[i][j] == message[i][j + 1])
                    {
                        equalSec++;
                    }
                    else
                    {
                        if (equalSec != 1)
                        {
                            bonus += equalSec;
                        }

                        equalSec = 1;
                    }
                }
                if (equalSec != 1)
                {
                    bonus += equalSec;
                }
                occ[message[i][message[i].Length - 1] - '0']++;
                result += (char)(3 * occ[0] + 5 * occ[1] + bonus);
            }
            Console.WriteLine(result);
        }
    }
}
