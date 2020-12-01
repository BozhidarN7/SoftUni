using System;
using System.Linq;

namespace _4.CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (char)(input[i] + 3);
            }
            Console.WriteLine(string.Join("",input));
        }
    }
}


