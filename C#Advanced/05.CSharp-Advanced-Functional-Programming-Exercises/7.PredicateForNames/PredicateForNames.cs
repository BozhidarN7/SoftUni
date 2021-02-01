using System;
using System.Linq;

namespace _7.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.ReadLine().Split().Where(x => x.Length <= n).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
