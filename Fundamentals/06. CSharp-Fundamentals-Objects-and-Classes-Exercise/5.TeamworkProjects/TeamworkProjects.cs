using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount;i++)
            {
                string[] input = Console.ReadLine().Split('-');
                string creator = input[0];
                string teamName = input[1];

                if (teams.Select(x => x.TeamName).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if(teams.Select(x => x.CreatorName).Contains(creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    teams.Add(new Team(creator, teamName));
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string command = Console.ReadLine();
            while (command != "end of assignment")
            {
                string[] tokens = command.Split("->");
                string user = tokens[0];
                string teamName = tokens[1];

                if (!teams.Select(x=>x.TeamName).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Select(x=>x.Members).Any(x => x.Contains(user)) || teams.Select(x => x.CreatorName).Contains(user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    int teamToJointIndex = teams.FindIndex(x => x.TeamName == teamName);
                    teams[teamToJointIndex].Members.Add(user);
                }

                command = Console.ReadLine();
            }

            List<Team> disbanedTeams = teams.OrderBy(x =>x.TeamName).Where(x => x.Members.Count == 0).ToList();
            List<Team> fullTeams = teams.Where(x => x.Members.Count > 0).OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList();
            foreach (Team team in fullTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach(string member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team team in disbanedTeams)
            {
                Console.WriteLine(team.TeamName);
            }

        }

    }

    public class Team
    {
        public string CreatorName { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public Team(string creator,string teamName)
        {
            CreatorName = creator;
            TeamName = teamName;
            Members = new List<string>();
        }

    }

}
