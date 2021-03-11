using System;
using System.Collections.Generic;
using System.Text;
using _4.WildFarm.Foods;

namespace _4.WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, double weightModifier, HashSet<string> allowedFoods)
        {
            Name = name;
            Weight = weight;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }
        public HashSet<string> AllowedFoods { get; private set; }
        public double WeightModifier { get; private set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; } = 0;
        public abstract string AskForFood();

        public void Eat(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += food.Quantity * WeightModifier;
            FoodEaten += food.Quantity;
        }
    }
}
