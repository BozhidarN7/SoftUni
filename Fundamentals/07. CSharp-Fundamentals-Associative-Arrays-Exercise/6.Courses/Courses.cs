using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (!courses.ContainsKey(tokens[0]))
                {
                    courses.Add(tokens[0], new List<string>());
                }
                courses[tokens[0]].Add(tokens[1]);
                input = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var user in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
