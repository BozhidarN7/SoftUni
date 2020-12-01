using System;

namespace _10.PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int temp = n;
            int hitTargest = 0;
            while (n >= m)
            {
                n = n - m;
                hitTargest++;

                if (n * 2 == temp && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(hitTargest);
        }
    }
}
