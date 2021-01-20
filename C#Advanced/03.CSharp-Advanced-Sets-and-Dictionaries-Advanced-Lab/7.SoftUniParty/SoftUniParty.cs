using System;
using System.Collections.Generic;

namespace _7.SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipGuests.Remove(input);
                }
                else
                {
                    regularGuests.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach(string vip in vipGuests)
            {
                Console.WriteLine(vip);
            }
            Console.WriteLine(string.Join("\n", regularGuests));
        }
    }
}
