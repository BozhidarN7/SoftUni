using System;
using System.Linq;

namespace _9.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Predicate<int> isDivisable = num =>
            {
                foreach (int divider in dividers)
                {
                    if (num % divider != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
            for (int i = 1; i <= n; i++)
            {
                if (isDivisable(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
