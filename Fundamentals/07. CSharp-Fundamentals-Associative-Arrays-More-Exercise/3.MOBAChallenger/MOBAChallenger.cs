using System;
using System.Collections.Generic;
using System.Linq;
namespace _3.MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> playersTotalPoints = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Season end")
            {
                List<string> tokens = input.Split().ToList();
                tokens.RemoveAll(x => x == "->");

                if (tokens[1] == "vs")
                {
                    string userOne = tokens[0];
                    string userTwo = tokens[2];

                    if (players.ContainsKey(userOne) && players.ContainsKey(userTwo))
                    {
                        string looser = string.Empty;
                        foreach (var item in players[userOne])
                        {
                            if (players[userTwo].ContainsKey(item.Key))
                            {
                                if (playersTotalPoints[userOne] > playersTotalPoints[userTwo])
                                {
                                    looser = userTwo;
                                }
                                else if (playersTotalPoints[userOne] < playersTotalPoints[userTwo])
                                {
                                    looser = userOne;
                                }
                                break;
                            }
                        }

                        players.Remove(looser);
                        playersTotalPoints.Remove(looser);
                    }
                }
                else
                {
                    string user = tokens[0];
                    string position = tokens[1];
                    int skills = int.Parse(tokens[2]);

                    if (!players.ContainsKey(user))
                    {
                        players.Add(user, new Dictionary<string, int>());
                    }
                    if (!players[user].ContainsKey(position))
                    {
                        players[user].Add(position, skills);
                    }
                    if (!playersTotalPoints.ContainsKey(user))
                    {
                        playersTotalPoints.Add(user, 0);
                    }
                    playersTotalPoints[user] += skills;

                    if (players[user][position] < skills)
                    {
                        playersTotalPoints[user] -= players[user][position];
                        players[user][position] = skills;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var player in playersTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value} skill");
                foreach (var item in players[player.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
