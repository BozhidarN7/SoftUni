using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public class Druid : BaseHero
    {
        private const int HeroPower = 80;
        public Druid(string name) 
            : base(name, HeroPower)
        { 
        }
        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {Name} healed for {Power}";
        }
    }
}
