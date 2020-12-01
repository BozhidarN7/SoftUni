using System;

namespace _2.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string str1 = input[0];
            string str2 = input[1];

            int sum = 0;
            int i;
            for (i = 0; i < str1.Length && i < str2.Length; i++)
            {
                sum += str1[i] * str2[i];
            }
            for (; i < Math.Max(str1.Length, str2.Length); i++)
            {
                sum += str1.Length > str2.Length ? str1[i] : str2[i];
            }

            Console.WriteLine(sum);
        }
    }
}
