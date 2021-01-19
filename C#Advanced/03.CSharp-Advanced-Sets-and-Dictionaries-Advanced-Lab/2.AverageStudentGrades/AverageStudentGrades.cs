using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dic = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dic.ContainsKey(name))
                {
                    dic.Add(name, new List<decimal>());
                }
                dic[name].Add(grade);
            }

            foreach (var pair in dic)
            {
                Console.WriteLine($"{pair.Key:f2} -> {string.Join(" ", pair.Value.Select(x => string.Format($"{x:f2}")))} (avg: {pair.Value.Average():f2})");
            }
        }
    }
}
