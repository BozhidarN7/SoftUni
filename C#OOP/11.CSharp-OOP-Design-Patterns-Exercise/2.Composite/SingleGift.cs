using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the prie {price}");

            return price;
        }
    }
}
