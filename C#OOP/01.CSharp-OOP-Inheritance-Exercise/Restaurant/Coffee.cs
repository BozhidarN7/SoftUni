using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double milliliters = 50;
        private const decimal price = 3.50m;
        public Coffee(string name, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
        public override double Milliliters { get; set; }
        public override decimal Price { get; set; }
    }
}
