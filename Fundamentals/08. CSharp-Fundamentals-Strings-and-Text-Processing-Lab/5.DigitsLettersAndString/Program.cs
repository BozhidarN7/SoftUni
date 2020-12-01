using System;

namespace _5.DigitsLettersAndString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string letters = "";
            string digits = "";
            string symbols = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    digits += input[i];
                }
                else if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    letters += input[i];
                }
                else
                {
                    symbols += input[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(symbols);
        }
    }
}
