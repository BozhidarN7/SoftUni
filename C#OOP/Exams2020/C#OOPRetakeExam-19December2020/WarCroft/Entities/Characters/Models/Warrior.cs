using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters.Models
{
    public class Warrior : Character, IAttacker
    {
        private const double DefaultBaseHealth = 100;
        private const double DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name)
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.CharacterAttacksSelf);
            }
            if (IsAlive && character.IsAlive)
            {
                character.TakeDamage(AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
