using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split('|');
            List<int> result = new List<int>();
            for (int i = line.Length - 1;  i >=0; i--)
            {
                result.AddRange(line[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            foreach( var number in result)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
