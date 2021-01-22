using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> usersAndContests = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(':');
                if (!contestsAndPasswords.ContainsKey(tokens[0]))
                {
                    contestsAndPasswords.Add(tokens[0], tokens[1]);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contest = tokens[0];
                string pass = tokens[1];
                string user = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestsAndPasswords.ContainsKey(contest) && contestsAndPasswords[contest] == pass)
                {
                    if (!usersAndContests.ContainsKey(user))
                    {
                        usersAndContests.Add(user, new Dictionary<string, int>());
                    }
                    if (!usersAndContests[user].ContainsKey(contest))
                    {
                        usersAndContests[user].Add(contest, 0);
                    }

                    usersAndContests[user][contest] = Math.Max(usersAndContests[user][contest], points);
                }
                input = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = usersAndContests.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");


            foreach ((string user, Dictionary<string, int> contests) in usersAndContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(user);
                foreach ((string contest, int points) in contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
