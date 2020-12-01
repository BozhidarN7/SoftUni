using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.SoftUniExamResults
{
    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> byUsers = new Dictionary<string, int>();
            Dictionary<string, int> byLenguage = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] tokens = input.Split('-');

                if (tokens[1] == "banned")
                {
                    byUsers.Remove(tokens[0]);
                    input = Console.ReadLine();
                    continue;
                }

                if (!byUsers.ContainsKey(tokens[0]))
                {
                    byUsers.Add(tokens[0], 0);
                }
                byUsers[tokens[0]] = Math.Max(byUsers[tokens[0]], int.Parse(tokens[2]));

                if (!byLenguage.ContainsKey(tokens[1]))
                {
                    byLenguage.Add(tokens[1], 0);
                }
                byLenguage[tokens[1]]++;
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var user in byUsers.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in byLenguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
