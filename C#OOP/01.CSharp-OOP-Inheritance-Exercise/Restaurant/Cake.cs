using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal price = 5;
        private const double calories = 1000;
        private const double grams = 250;
        public Cake(string name) : base(name, price, calories, grams)
        {
        }
        public override decimal Price { get; set; }
        public override double Calories { get; set; }
        public override double Grams { get; set; }
    }

}
