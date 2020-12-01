using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _2.Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] tokens = input.Split(" -> ");
                string contest = tokens[1];
                string user = tokens[0];
                int points = int.Parse(tokens[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                }

                if (!contests[contest].ContainsKey(user))
                {
                    contests[contest].Add(user, points);
                }
                if (!users.ContainsKey(user))
                {
                    users.Add(user, 0);
                }
                users[user] += points;

                if (contests[contest][user] < points)
                {
                    users[user] -= contests[contest][user];
                    contests[contest][user] = points;
                }

                input = Console.ReadLine();
            }

            int index = 0;
            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                index = 1;
                foreach (var item in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{index++}. {item.Key} <::> {item.Value}");
                }
            }
            Console.WriteLine("Individual standings:");
            index = 1;
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{index++}. {user.Key} -> {user.Value}");
            }
        }
    }
}
