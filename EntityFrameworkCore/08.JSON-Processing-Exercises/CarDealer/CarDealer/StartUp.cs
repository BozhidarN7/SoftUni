using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");

            Console.WriteLine(ImportSuppliers(context, inputSuppliers));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            List<SupplierInputDto> suppliersDto = JsonConvert.DeserializeObject<List<SupplierInputDto>>(inputJson);
            List<Supplier> mappedSuppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(mappedSuppliers);

            return $"Successfully imported {suppliersDto.Count}";
        }

        private static void InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }
    }
}