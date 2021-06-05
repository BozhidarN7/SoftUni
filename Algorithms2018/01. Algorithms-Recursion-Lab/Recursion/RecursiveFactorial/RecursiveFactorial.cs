using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFactorial
{
    class RecursiveFactorial
    {
        static void Main(string[] args)
        {
            int result = CalcFactorial(int.Parse(Console.ReadLine()));

            Console.WriteLine(result);
        }

        private static int CalcFactorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * CalcFactorial(number - 1);
        }
    }
}
