using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _6.StoreBoxes
{
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();

                Box currentBox = new Box();
                currentBox.SerialNumber = tokens[0];
                currentBox.Item.Name = tokens[1];
                currentBox.Item.Price = decimal.Parse(tokens[3]);
                currentBox.Quantity = int.Parse(tokens[2]);
                currentBox.PriceBox = currentBox.Quantity * currentBox.Item.Price;
                boxes.Add(currentBox);

                command = Console.ReadLine();
            }

            boxes.OrderByDescending(x => x.PriceBox).ToList().ForEach(x =>
            {
                Console.WriteLine(x.SerialNumber);
                Console.WriteLine($"-- {x.Item.Name} - ${x.Item.Price:f2}: {x.Quantity}");
                Console.WriteLine($"-- ${x.PriceBox:f2}");
            });
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }

        public Box()
        {
            Item = new Item();
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
