using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label,decimal price, int quantity)
        {
            this.label = label;
            this.price = price;
            this.quantity = quantity;
        }
        public string Label => label;

        public decimal Price => price;

        public int Quantity => quantity;

        public int CompareTo( IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
