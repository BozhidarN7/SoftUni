using System;
using System.Text;

namespace _7.RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            ConcatString(text, times);
        }

        private static void ConcatString(string text, int times)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                sb.Append(text);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
