using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public class Warrior : BaseHero
    {
        private const int HeroPower = 100;
        public Warrior(string name)
            : base(name, HeroPower)
        {
        }
        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";
        }
    }
}
