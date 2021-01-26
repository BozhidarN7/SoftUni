using System;
using System.Linq;

namespace _3.CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> IsWordStartingWithCapitalLetter = (word) => word[0] >= 'A' && word[0] <= 'Z';

             Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x => IsWordStartingWithCapitalLetter(x)).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
