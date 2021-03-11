using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DogWeightModifier = 0.40;
        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion,DogWeightModifier,allowedFoods)
        {
        }
        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
