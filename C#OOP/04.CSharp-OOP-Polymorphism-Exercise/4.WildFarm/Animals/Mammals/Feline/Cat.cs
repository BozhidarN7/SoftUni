using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.30;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable)
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed, CatWeightModifier, allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
