using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightModifier = 0.10;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Fruit),
            nameof(Vegetable)
        };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion,MouseWeightModifier, allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
