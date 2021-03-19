using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players.Models
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }
        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => username;
            private set
            {
                Validator.ThrowIfStringIsInvalid(value,ConstantMessages.InvalidNameMessage);
                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                Validator.ThrowIfNumberIsNegative(value, ConstantMessages.NegativeNumberMessage);
                health = value;
            }
        }

        public bool IsDead
        {
            get
            {
                if (health <= 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfNumberIsNegative(damagePoints, ConstantMessages.NegativeDamageMessage);
            health -= damagePoints;
            if (health < 0)
            {
                health = 0;
            }
        }
        public override string ToString()
        {
            return string.Format(ConstantMessages.PlayerReportInfo, Username, Health, CardRepository.Count);
        }
    }
}
