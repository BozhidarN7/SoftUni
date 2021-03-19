using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public IPlayer First
        {
            get
            {
                if (players.Count == 0)
                {
                    throw new ArgumentException("There are no players");
                }
                return players[0];
            }
        }

        public void Add(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (Find(player.Username) != null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (!players.Remove(player))
            {
                throw new ArgumentException("Player cannot be null");
            }
            return true;
        }
    }
}
