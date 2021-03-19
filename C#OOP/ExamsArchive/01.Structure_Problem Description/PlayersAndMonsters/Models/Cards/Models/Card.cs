using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Models
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name,int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsInvalid(value, ConstantMessages.InvalidCardNameMessage);
                name = value;
            }
        }

        public int DamagePoints
        {
            get => damagePoints;
            set
            {
                Validator.ThrowIfNumberIsNegative(value, ConstantMessages.NegativeCardDamagePointsMessage);
                damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => healthPoints;
            private set
            {
                Validator.ThrowIfNumberIsNegative(value, ConstantMessages.NegativeHealthPointsMessage);
                healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo, Name, DamagePoints);
        }
    }
}
