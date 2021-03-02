using System;
using System.Collections.Generic;

namespace _5.FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                try
                {
                    if (command == "Add")
                    {
                        string teamName = tokens[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            line = Console.ReadLine();
                            continue;
                        }

                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        Team team = teams[teamName];
                        team.AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = tokens[1];
                        string playerName = tokens[2];

                        Team team = teams[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = tokens[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            line = Console.ReadLine();
                            continue;
                        }
                        Team team = teams[teamName];
                        Console.WriteLine($"{teamName} - {team.AverageRating}");
                    }
                    else
                    {
                        string teamName = tokens[1];
                        Team team = new Team(teamName);
                        teams.Add(team.Name, team);
                    }
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
