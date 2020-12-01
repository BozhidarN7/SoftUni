using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.RepeatStrings
{
    class RepeatStrings
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine().Split().ToList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j< arr[i].Length; j++)
                {
                    sb.Append(arr[i]);
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
