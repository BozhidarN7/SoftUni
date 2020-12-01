using System;
using System.Linq;

namespace _4.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banners = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < banners.Length; i++)
            {
                text = text.Replace(banners[i], new string('*', banners[i].Length));
            }
            Console.WriteLine(text);
        }
    }
}
