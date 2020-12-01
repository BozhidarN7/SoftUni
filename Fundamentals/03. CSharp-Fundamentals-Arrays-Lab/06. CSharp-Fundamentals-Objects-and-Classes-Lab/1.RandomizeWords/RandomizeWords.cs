using System;

namespace _1.RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rnd = new Random();
            for (int i = 0; i < words.Length; i++)
            {
                Swap(words, i, rnd.Next(0, words.Length));
            }

            Console.WriteLine(string.Join("\n", words));
        }

        private static void Swap(string[] words, int i, int j)
        {
            string temp = words[i];
            words[i] = words[j];
            words[j] = temp;
        }
    }
}
