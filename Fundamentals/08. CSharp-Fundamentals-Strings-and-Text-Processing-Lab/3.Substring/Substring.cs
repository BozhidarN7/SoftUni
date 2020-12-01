using System;

namespace _3.Substring
{
    class Substring
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string str = Console.ReadLine();

            pattern = pattern.ToLower();
            str = str.ToLower();

            int index = str.IndexOf(pattern);
            while (index >= 0)
            {
                str = str.Remove(index, pattern.Length);
                index = str.IndexOf(pattern);
            }

            Console.WriteLine(str);
        }
    }
}
