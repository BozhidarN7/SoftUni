using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public  class FreshwaterFish : Fish
    {
        private const int DefaultSize = 3;
        private const int DefaultSizeModifier = 3;
        public FreshwaterFish(string name, string species, decimal price) 
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
