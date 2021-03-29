﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters.Models
{
    public class Priest : Character, IHealer
    {
        private const double DefaultBaseHealth = 50;
        private const double DefaultBaseArmor = 25;
        private const double DefaultAbilityPoints = 40;
        private static readonly IBag DefaultBag = new Backpack();
        public Priest(string name)
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, DefaultBag)
        {
        }

        public void Heal(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                character.Health += AbilityPoints;
            }
        }
    }
}
