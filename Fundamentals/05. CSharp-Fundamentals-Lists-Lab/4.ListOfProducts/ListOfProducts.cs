using System;
using System.Collections.Generic;

namespace _4.ListOfProducts
{
    class ListOfProducts
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>(new string[n]);
            for (int i = 0; i < n; i++)
            {
                list[i] = Console.ReadLine();
            }

            list.Sort();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i +1}.{list[i]}");
            }
        }
    }
}
