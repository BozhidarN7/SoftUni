using System;
using System.Collections.Generic;

namespace _5.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!symbols.ContainsKey(str[i]))
                {
                    symbols.Add(str[i], 0);
                }
                symbols[str[i]]++;
            }
            foreach (var pair in symbols)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
