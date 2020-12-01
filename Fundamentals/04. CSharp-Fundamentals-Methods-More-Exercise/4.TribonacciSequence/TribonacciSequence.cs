using System;

namespace _4.TribonacciSequence
{
    class TribonacciSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintFirstN(n);

        }

        private static void PrintFirstN(int n)
        {
            int first = 1;
            int second = 1;
            int third = 2;

            Console.Write(first + " ");
            if (n > 1)
            {
                Console.Write(second + " ");
            }

            if (n > 2)
            {
                Console.Write(third + " ");
            }

            for (int i = 3; i < n; i++)
            {
                int curr = first + second + third;
                first = second;
                second = third;
                third = curr;

                Console.Write(curr + " ");
            }

        }
    }
}
