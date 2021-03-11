using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize, double weightModifier, HashSet<string> allowedFoods)
            : base(name, weight, weightModifier, allowedFoods)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
