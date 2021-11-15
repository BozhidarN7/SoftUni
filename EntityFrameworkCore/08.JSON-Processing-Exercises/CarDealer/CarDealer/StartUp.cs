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
            string inputParts = File.ReadAllText("../../../Datasets/parts.json");
            string inputCars = File.ReadAllText("../../../Datasets/cars.json");

            Console.WriteLine(ImportSuppliers(context, inputSuppliers));
            Console.WriteLine(ImportParts(context, inputParts));
            Console.WriteLine(ImportCars(context, inputCars));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            List<SupplierInputDto> suppliersDto = JsonConvert.DeserializeObject<List<SupplierInputDto>>(inputJson);
            List<Supplier> mappedSuppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliersDto.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            int lastSupplierId = context.Suppliers.Max(s => s.Id);
            List<PartsInputDto> partsDto = JsonConvert.DeserializeObject<List<PartsInputDto>>(inputJson).Where(p => p.SupplierId <= lastSupplierId).ToList();
            List<Part> mappedParts = mapper.Map<List<Part>>(partsDto);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            List<CarsInputDto> carsDto = JsonConvert.DeserializeObject<List<CarsInputDto>>(inputJson);
            List<Car> mappedCars = new List<Car>();

            foreach (CarsInputDto car in carsDto)
            {
                Car vehicle = mapper.Map<CarsInputDto,Car>(car);
                mappedCars.Add(vehicle);

                List<int> partIds = car.PartsId.Distinct().ToList();


                if (partIds == null)
                {
                    continue;
                }

                partIds.ForEach(pid =>
                {
                    PartCar currentPair = new PartCar()
                    {
                        Car = vehicle,
                        PartId = pid
                    };
                    vehicle.PartCars.Add(currentPair);
                });
            }

            context.Cars.AddRange(mappedCars);
            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count}.";
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