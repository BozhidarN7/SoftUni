using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<char> reversedStr = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                reversedStr.Push(str[i]);
            }
            while(reversedStr.Count != 0)
            {
                Console.Write(reversedStr.Pop());
            }
        }
    }
}
