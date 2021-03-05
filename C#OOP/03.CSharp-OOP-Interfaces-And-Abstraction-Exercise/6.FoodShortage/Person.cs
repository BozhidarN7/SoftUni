using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public abstract class Person : IPerson
    {
        public string Name  { get; protected set; }

        public int Age { get; protected set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
