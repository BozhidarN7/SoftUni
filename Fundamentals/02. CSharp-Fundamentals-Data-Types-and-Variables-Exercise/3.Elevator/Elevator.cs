using System;

namespace _3.Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int result = n / p;

            if (result * p != n)
            {
                result++;
            }

            Console.WriteLine(result);
        }
    }
}
