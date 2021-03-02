using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PIzzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string ExceptionMessage = "Invalid type of dough.";
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException(ExceptionMessage);
                }
                flourType = valueAsLower;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                Validator.ThrowIfInvalidType(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), ExceptionMessage);
                bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            return weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueLower = bakingTechnique.ToLower();
            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }
            return 1.0;
        }

        private double GetFlourTypeModifier()
        {
            string flourTypeLower = flourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            return 1.0;
        }
    }
}
