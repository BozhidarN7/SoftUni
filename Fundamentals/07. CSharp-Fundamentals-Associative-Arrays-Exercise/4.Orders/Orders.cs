using System;
using System.Collections.Generic;

namespace _4.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] tokens = input.Split();

                if (!products.ContainsKey(tokens[0]))
                {
                    products.Add(tokens[0], new Product(tokens[0], double.Parse(tokens[1]), int.Parse(tokens[2])));
                }
                else
                {
                    products[tokens[0]].Quantity += int.Parse(tokens[2]);
                    products[tokens[0]].Price = double.Parse(tokens[1]);
                }
                input = Console.ReadLine();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price * product.Value.Quantity:f2}");
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
