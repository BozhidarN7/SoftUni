using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public class Rebel : Person, IRebel
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public override void BuyFood()
        {
            Food += 5;
        }
        public string Group { get; private set; }
    }
}
