using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        void BuyProduct(string id);
        IEnumerable<CartViewModel> AddProduct(string productId, string userId);
        IEnumerable<CartViewModel> GetProducts(string id);
    }
}
