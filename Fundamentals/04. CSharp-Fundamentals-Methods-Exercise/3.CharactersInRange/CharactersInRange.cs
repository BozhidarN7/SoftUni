using System;

namespace _3.CharactersInRange
{
    class CharactersInRange
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintAllBetween(start, end);

        }

        private static void PrintAllBetween(char start, char end)
        {
            if (start > end)
            {
                char temp = start;
                start = end;
                end = temp;
                
            }

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
