using System;
using System.ComponentModel;

namespace _6.TriBitSwitch
{
    class TriBitSwitch
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            Console.WriteLine(number ^ (7 << p));
        }
    }
}
