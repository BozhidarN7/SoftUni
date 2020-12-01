using System;
using System.Collections.Specialized;
using System.Linq;

namespace _1.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());

            string binary = ToBinary(number);
            int count = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] - '0' == B)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static string ToBinary(int number)
        {
            string digits = "01";
            string result = "";

            while (number != 0)
            {
                result = result + digits[number % 2].ToString();
                number /= 2;
            }

            return result;
        }
    }
}
