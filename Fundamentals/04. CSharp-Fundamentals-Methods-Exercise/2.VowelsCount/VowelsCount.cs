using System;

namespace _2.VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string vowels = "aoueiAOUEI";
            string input = Console.ReadLine();

            CountVowels(input, vowels);
        }

        private static void CountVowels(string input, string vowels)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
