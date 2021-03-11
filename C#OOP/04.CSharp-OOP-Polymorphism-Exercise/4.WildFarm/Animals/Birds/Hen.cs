using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Seeds),
            nameof(Fruit)
        };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize, HenWeightModifier, allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
