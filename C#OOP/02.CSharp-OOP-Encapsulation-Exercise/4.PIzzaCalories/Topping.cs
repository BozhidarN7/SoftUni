using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PIzzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType
        {
            get => toppingType;
            private set
            {
                Validator.ThrowIfInvalidType(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, value.ToLower(), $"Cannot place {value} on top of your pizza.");
                toppingType = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"{toppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
                weight = value;
            }
        }

        public double GetCalories()
        {
            double modifier = GetModifier();
            return modifier * Weight * 2;
        }

        private double GetModifier()
        {
            string typeLower = toppingType.ToLower();
            if (typeLower == "meat")
            {
                return 1.2;
            }
            else if (typeLower == "veggies")
            {
                return 0.8;
            }
            else if (typeLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
