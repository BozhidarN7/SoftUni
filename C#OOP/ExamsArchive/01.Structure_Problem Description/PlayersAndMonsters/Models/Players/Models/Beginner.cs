using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players.Models
{
    public class Beginner : Player
    {
        private const int HealthPoints = 50;
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, HealthPoints)
        {
        }
    }
}
