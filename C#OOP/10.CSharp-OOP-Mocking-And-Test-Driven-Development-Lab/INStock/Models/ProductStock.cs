using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }
        public IProduct this[int index] { get => products[index]; set => products[index] = value; }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (IProduct currProduct in products)
            {
                if (currProduct.Label == product.Label)
                {
                    return true;
                }
            }
            return false;
        }

        public IProduct Find(int index)
        {
            if (index >= products.Count)
            {
                throw new IndexOutOfRangeException($"Index must be less than {Count}");
            }
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return products.Where(x => x.Price == (decimal)price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(x => x.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return products.Where(x => x.Price >= (decimal)lo && x.Price <= (decimal)hi).OrderByDescending(x => x.Price);
        }

        public IProduct FindByLabel(string label)
        {
            return products.FirstOrDefault(x => x.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return products.OrderByDescending(x => x.Price).FirstOrDefault();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (Product product in products)
            {
                yield return product;
            }
        }

        public bool Remove(IProduct product)
        {
            return products.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
