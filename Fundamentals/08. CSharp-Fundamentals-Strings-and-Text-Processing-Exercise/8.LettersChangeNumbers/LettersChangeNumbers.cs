using System;

namespace _8.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i][0];
                char lastletter = input[i][input[i].Length - 1];
                double number = double.Parse(input[i].Substring(1, input[i].Length - 2));

                if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    number = number * (firstLetter - 'a' + 1);
                }
                else if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    number = number / (double)(firstLetter - 'A' + 1);
                }

                if (lastletter >= 'a' && lastletter <= 'z')
                {
                    number = number + (lastletter - 'a' + 1);
                }
                else if (lastletter >= 'A' && lastletter <= 'Z')
                {
                    number = number - (lastletter - 'A' + 1);
                }

                result += number;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
