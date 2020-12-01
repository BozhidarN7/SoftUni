using System;
using System.ComponentModel.DataAnnotations;

namespace _9.PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            while (number != "END")
            {
                bool isPalindorme = CheckPalindrome(number);
                if (isPalindorme)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                number = Console.ReadLine();
            }
        }

        private static bool CheckPalindrome(string number)
        {
            bool isPalindrome = true;
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - i -1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
