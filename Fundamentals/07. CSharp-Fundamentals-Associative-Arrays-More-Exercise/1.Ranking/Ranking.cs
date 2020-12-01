using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(':');
                if (!contests.ContainsKey(tokens[0]))
                {
                    contests.Add(tokens[0], tokens[1]);
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

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new Dictionary<string, int>());
                    }
                    if (!users[user].ContainsKey(contest))
                    {
                        users[user].Add(contest, points);
                    }
                    else 
                    {
                        if (users[user][contest] < points)
                        {
                            users[user][contest] = points;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            // Using LINQ 
            KeyValuePair<string, int> userMaxPoints = users.Select(user =>
              {
                  int points = 0;
                  foreach (var item in user.Value)
                  {
                      points += item.Value;
                  }
                  return new KeyValuePair<string, int>(user.Key, points);
              }).OrderByDescending(x => x.Value).First();


            // Using Loops

            /*string userName = "";
            int maxPoints = 0;
            foreach (var user in users)
            {
                int currentMax = 0;

                foreach (var item in user.Value)
                {
                    currentMax += item.Value;
                }

                if (currentMax > maxPoints)
                {
                    maxPoints = currentMax;
                    userName = user.Key;
                }
            }*/

            Console.WriteLine($"Best candidate is {userMaxPoints.Key} with total {userMaxPoints.Value} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
