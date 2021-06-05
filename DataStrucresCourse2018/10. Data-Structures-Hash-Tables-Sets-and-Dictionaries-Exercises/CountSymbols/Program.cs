using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            if (symbols.ContainsKey(input[i]))
            {
                symbols[input[i]]++;
            }
            else
            {
                symbols[input[i]] = 1;
            }
        }

        foreach (var symbol in symbols)
        {
            Console.WriteLine("{0}: {1} time/s",symbol.Key,symbol.Value);
        }
    }
}

