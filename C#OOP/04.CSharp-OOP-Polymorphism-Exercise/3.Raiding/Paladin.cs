using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public class Paladin : BaseHero
    {
        private const int HeroPower = 100;
        public Paladin(string name)
            :base(name,HeroPower)
        {
        }
        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {Name} healed for {Power}";
        }
    }
}
