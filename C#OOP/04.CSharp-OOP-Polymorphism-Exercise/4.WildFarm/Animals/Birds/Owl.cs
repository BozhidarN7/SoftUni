using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize, OwlWeightModifier, allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
