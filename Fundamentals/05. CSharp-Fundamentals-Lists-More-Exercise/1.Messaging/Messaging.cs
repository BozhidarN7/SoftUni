using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Messaging
{
    class Messaging
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();

            for (int i = 0; i < numbers.Count; i++)
            {
                int digitSum = FindSumOfDigits(numbers[i]);
                int index = digitSum % text.Length ;

                Console.Write(text[index]);

                text = RemoveCharackter(text, index);
            }

        }

        private static string RemoveCharackter(string text, int index)
        {
            string firstPart = text.Substring(0, index);
            string secondPart = text.Substring(index + 1);

            return firstPart + secondPart;
        }

        private static int FindSumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                {
                    sum += number % 10;
                    number /= 10;
                }
            }
            return sum;
        }
    }
}
