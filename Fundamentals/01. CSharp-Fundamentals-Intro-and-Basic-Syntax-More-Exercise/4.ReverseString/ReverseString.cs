using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _4.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            input = new string(arr);
            Console.WriteLine(input);
        }
    }
}
