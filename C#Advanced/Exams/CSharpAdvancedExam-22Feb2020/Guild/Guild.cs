using System;
using System.Collections.Generic;
using System.Linq;
namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => roster.Count;
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string classInput)
        {
            List<Player> playersToRemove = roster.Where(x => x.Class == classInput).ToList();
            playersToRemove.ForEach(x => roster.Remove(x));
            return playersToRemove.ToArray();
        }
        public string Report()
        {
            string result = $"Players in the guild: {Name}{Environment.NewLine}";
            result += string.Join(Environment.NewLine, roster);
            return result;
        }
    }
}
