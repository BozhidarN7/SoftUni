using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Models
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();

        }
        public int Capacity { get; set; }

        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items =>items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.EmptyBag);
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.ItemNotFoundInBag, name));
            }
            return item;
        }
    }
}
