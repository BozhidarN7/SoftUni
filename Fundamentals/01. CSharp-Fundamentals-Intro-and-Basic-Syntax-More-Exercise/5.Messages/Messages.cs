using System;

namespace _5.Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string result = string.Empty;
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                int digit = int.Parse(input[input.Length - 1].ToString());

                if (digit== 0)
                {
                    result += " ";
                    continue;
                }

                int offset = (digit - 2) * 3;
                if (digit == 8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + input.Length - 1;
                result += (char)((int)'a' + letterIndex);
            }

            Console.WriteLine(result);
        }
    }
}
