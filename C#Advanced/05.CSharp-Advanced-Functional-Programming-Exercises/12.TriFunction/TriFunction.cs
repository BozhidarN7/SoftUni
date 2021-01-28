using System;
using System.Linq;
namespace _12.TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] name = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Iterate(name, FindSpecialWord(), n);

        }

        private static void Iterate(string[] name, Func<string, int, bool> findSpecialWord, int n)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (findSpecialWord(name[i],n))
                {
                    Console.WriteLine(name[i]);
                    return;
                }
            }
        }

        private static Func<string, int, bool> FindSpecialWord()
        {
            return (str, n) =>
            {
                int sum = str.Select(c => (int)c).Sum();
                if (sum >= n) return true;
                return false;
            };
        }
    }
}
