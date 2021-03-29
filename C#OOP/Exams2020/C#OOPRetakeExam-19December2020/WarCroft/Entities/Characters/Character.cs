using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private const int MinHealth = 0;
        private const int MinArmor = 0;
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = BaseHealth;
            BaseArmor = armor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Constants.ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => health;
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value <= MinHealth)
                {
                    health = MinHealth;
                    IsAlive = false;
                }
                else
                {
                    health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => armor;
            private set
            {
                if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else if (value <= MinArmor)
                {
                    armor = MinArmor;
                }
                else
                {
                    armor = value;
                }
            }
        }
        public double AbilityPoints { get; private set; }
        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                double temp = Armor;
                Armor -= hitPoints;
                hitPoints -= temp;

                if (hitPoints > 0)
                {
                    Health -= hitPoints;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {(IsAlive ? "Alive" : "Dead")}";
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}