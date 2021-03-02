using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;
        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfNameIsInvalid(value, "A name should not be empty");
                name = value;
            }
        }

        public double AverageRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return players.Values.Average(p => p.SkillLevel);
            }
        }
        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }
        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(playerName);
        }
    }
}
