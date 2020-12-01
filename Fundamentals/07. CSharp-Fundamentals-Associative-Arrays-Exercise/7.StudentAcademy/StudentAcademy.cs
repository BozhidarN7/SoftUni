using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            var newStudents = students.Select(x =>
            {
                double average = x.Value.Sum() / (double)x.Value.Count;
                if (average >= 4.50)
                {
                    return new KeyValuePair<string, double>(x.Key, average);
                }
                return new KeyValuePair<string, double>("", 0.0);
            }).Where(x => x.Key != "").ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in newStudents.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
