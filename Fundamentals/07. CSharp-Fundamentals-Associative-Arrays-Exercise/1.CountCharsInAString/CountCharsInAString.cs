using System;
using System.Collections.Generic;

namespace _1.CountCharsInAString
{
    class CountCharsInAString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> letterOccurence = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    continue;
                }

                if (!letterOccurence.ContainsKey(text[i]))
                {
                    letterOccurence.Add(text[i], 0);
                }
                letterOccurence[text[i]]++;
            }

            foreach (var item in letterOccurence)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
