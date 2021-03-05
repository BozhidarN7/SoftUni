using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; }
        public void BuyFood();
    }
}
