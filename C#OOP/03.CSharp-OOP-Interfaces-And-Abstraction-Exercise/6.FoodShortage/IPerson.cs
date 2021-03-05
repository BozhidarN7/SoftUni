using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public interface IPerson : IBuyer
    {
        public string Name { get; }
        public int Age { get; }
    }
}
