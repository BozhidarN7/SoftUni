using System;

namespace _6.MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCharacter(input);
        }

        private static void PrintMiddleCharacter(string input)
        {
            if (input.Length % 2 == 1)
            {
                Console.WriteLine(input[input.Length / 2]);
            }
            else
            {
                Console.WriteLine($"{input[input.Length / 2 - 1]}{input[input.Length / 2]}");
            }
        }
    }
}
