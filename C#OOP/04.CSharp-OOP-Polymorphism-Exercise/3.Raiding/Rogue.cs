using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public class Rogue : BaseHero
    {
        private const int HeroPower = 80;
        public Rogue(string name)
            : base(name, HeroPower)
        {
        }
        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }
    }
}
