using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class Program
{
    static void Main(string[] args)
    {
        var items = new FirstLastList<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        items.Last(2).ToList().ForEach(x=> Console.Write(x + " "));
    }

    class Product : IComparable<Product>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Product(decimal price, string title)
        {
            this.Price = price;
            this.Title = title;
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);

        }
    }
}
