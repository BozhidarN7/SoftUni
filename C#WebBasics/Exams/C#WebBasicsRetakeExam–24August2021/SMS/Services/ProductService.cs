using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public ProductService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }
        public (bool created, string error) Create(CreateProductViewModel model)
        {
            bool created = false;
            string error = null;

            (bool isValid, string validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = "Could not save product";
            }

            return (created, error);
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(p => new ProductListViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2"),
                    ProductId = p.Id
                })
                .ToList();
        }
    }
}
