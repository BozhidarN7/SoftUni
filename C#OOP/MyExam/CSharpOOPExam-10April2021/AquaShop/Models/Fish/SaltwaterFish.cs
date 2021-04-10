using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int DefaultSize = 5;
        private const int DefaultSizeModifier = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            Size = DefaultSize;
        }

        public override void Eat()
        {
            Size += DefaultSizeModifier;
        }
    }
}
