using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> dic = new Dictionary<double, int>();

            foreach(double number in numbers)
            {
                if (!dic.ContainsKey(number))
                {
                    dic.Add(number, 0);
                }
                dic[number]++;
            }

            foreach(var pair in dic)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
