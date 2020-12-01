using System;

namespace _1.SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());


            if (b < a)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            if (c < b)
            {
                int temp = b;
                b = c;
                c = temp;

                if (b < a)
                {
                    temp = a;
                    a = b;
                    b = temp;
                }
            }

            Console.WriteLine(c);
            Console.WriteLine(b);
            Console.WriteLine(a);
        }
    }
}
