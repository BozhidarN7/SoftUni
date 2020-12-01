using System;
using System.Collections.Generic;

namespace _2.AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(input))
                {
                    dic.Add(input, 0);   
                }
                dic[input] += quantity;

                input = Console.ReadLine();
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
