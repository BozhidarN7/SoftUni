using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.PIzzaCalories
{
    public class Pizza
    {
        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;
        private const int MinToppings = 0;
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;


        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }
                name = value;
            }
        }

        public int NumberOfToppings => toppings.Count;
        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= MaxToppings)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
            }
            toppings.Add(topping);
        }

        public double GetCalories()
        {
            return dough.GetCalories() + toppings.Sum(t => t.GetCalories());
        }
    }
}
