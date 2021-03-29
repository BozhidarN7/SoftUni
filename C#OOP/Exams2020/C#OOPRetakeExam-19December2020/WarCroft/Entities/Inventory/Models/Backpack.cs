using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory.Models
{
    public class Backpack : Bag
    {
        private const int DefaultCapacity = 100;
        public Backpack()
            : base(DefaultCapacity)
        {
        }
    }
}
