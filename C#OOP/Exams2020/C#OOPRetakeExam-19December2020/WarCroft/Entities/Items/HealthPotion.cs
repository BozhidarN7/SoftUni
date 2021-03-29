using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int ItemWeight = 5;
        private const int HealthModifier = 20;
        public HealthPotion()
            : base(ItemWeight)
        {
        }
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.IsAlive)
            {
                character.Health += HealthModifier;
            }
        }
    }
}
