using System;
using System.Collections.Generic;
using System.Text;

namespace _3.TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<char> symbols = new List<char>();
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] >= '0' && message[i] <= '9')
                {
                    numbers.Add(message[i] - '0');
                }
                else
                {
                    symbols.Add(message[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int position = 0;
            string text = string.Join("", symbols);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < takeList.Count; i++)
            {
                if (position + takeList[i] > text.Length)
                {
                    result.Append(text, position, text.Length - position);
                    break;
                }
                result.Append(text, position, takeList[i]);
                position += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
