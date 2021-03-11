using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed, double weightModifier, HashSet<string> allowedFoods)
            : base(name, weight, livingRegion, weightModifier, allowedFoods)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
