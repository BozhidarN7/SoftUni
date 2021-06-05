using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Fibonacci
{
    class Fibonacci
    {
        private static int[] fibNum;


        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            fibNum = new int[number + 1];

            Console.WriteLine(Fib(number));
        }

        private static int Fib(int number)
        {
            if (fibNum[number] != 0)
            {
                return fibNum[number];
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            var result = Fib(number - 1) + Fib(number - 2);

            fibNum[number] = result;

            return result;
        }
    }
}
