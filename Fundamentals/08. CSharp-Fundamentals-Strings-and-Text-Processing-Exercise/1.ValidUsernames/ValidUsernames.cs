using System;
using System.Collections.Generic;
using System.Linq;
namespace _1.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string allowedSymbols = "0123456789abcdefghijklmnopqrstuvwxyz-_";
            Console.ReadLine().Split(", ").Where(x => x.Length >= 3 && x.Length <= 16).Select(x =>
             {
                 foreach (var symbol in x)
                 {
                     if (!allowedSymbols.Contains(Char.ToLower(symbol)))
                     {
                         return string.Empty;
                     }
                 }
                 return x;
             }).Where(x =>x!=string.Empty).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
