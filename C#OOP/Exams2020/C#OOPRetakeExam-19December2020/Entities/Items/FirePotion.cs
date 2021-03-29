using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int ItemWeight = 5;
        private const int HealthModifier = 20;

        public FirePotion()
            : base(ItemWeight)
        {
        }
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.IsAlive)
            {
                character.Health -= HealthModifier;

                if (character.Health <= 0)
                {
                    character.Health = 0;
                    character.IsAlive = false;
                }
            }
        }
    }
}
