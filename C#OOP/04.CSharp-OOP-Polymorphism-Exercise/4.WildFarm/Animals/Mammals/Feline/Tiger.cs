using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.00;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, TigerWeightModifier, allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return $"ROAR!!!";
        }
    }
}
