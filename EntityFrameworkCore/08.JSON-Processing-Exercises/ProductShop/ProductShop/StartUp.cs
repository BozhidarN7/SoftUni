using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //string categoriesProductsInput = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(GetSoldProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            List<UserInputDto> users = JsonConvert.DeserializeObject<List<UserInputDto>>(inputJson);
            List<User> mappedUseres = mapper.Map<List<User>>(users);

            context.Users.AddRange(mappedUseres);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();
            List<ProductInputDto> products = JsonConvert.DeserializeObject<List<ProductInputDto>>(inputJson);
            List<Product> mappedProducts = mapper.Map<List<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeMapper();
            List<CategoryInputDto> categories = JsonConvert.DeserializeObject<List<CategoryInputDto>>(inputJson)
                .Where(c => c.Name != null && c.Name != String.Empty)
                .ToList();
            List<Category> mappedCategories = mapper.Map<List<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();
            List<CategoryProductInputDto> categoriesProducts = JsonConvert
                .DeserializeObject<List<CategoryProductInputDto>>(inputJson);
            List<CategoryProduct> mappedCategoriesProducts = mapper.Map<List<CategoryProduct>>(categoriesProducts);

            context.CategoryProducts.AddRange(mappedCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price < 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                })
                .ToList();

            string serialized = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            }); ;
            return serialized;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                });

            string serialized = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return serialized;
        }

        private static void InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }
    }
}