using System;
using System.Linq;
using System.Collections.Generic;
namespace _1.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                List<char> current = input.ToList();
                current.Reverse();
                Console.WriteLine($"{input} = {string.Join("",current)}");
                input = Console.ReadLine();
            }
            Console.WriteLine();
        }
    }
}
