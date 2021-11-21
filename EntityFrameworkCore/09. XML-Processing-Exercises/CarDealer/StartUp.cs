using CarDealer.Data;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersInput = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsInput = File.ReadAllText("../../../Datasets/parts.xml");
            string carsInput = File.ReadAllText("../../../Datasets/cars.xml");
            string customersInput = File.ReadAllText("../../../Datasets/customers.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersInput));
            Console.WriteLine(ImportParts(context, partsInput));
            Console.WriteLine(ImportCars(context, carsInput));
            Console.WriteLine(ImportCustomers(context, customersInput));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDto[] suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto supplierDto in suppliersDto)
            {
                Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImoprter)
                };
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartDto[] partsDto = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();
            foreach (ImportPartDto partDto in partsDto)
            {
                if (!context.Suppliers.Any(s => s.Id == int.Parse(partDto.SupplierId)))
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = partDto.Name,
                    Price = decimal.Parse(partDto.Price),
                    Quantity = int.Parse(partDto.Quantity),
                    SupplierId = int.Parse(partDto.SupplierId)
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] carsDto = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (ImportCarDto carDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();
                foreach (int partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context.Parts.Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        Part = part
                    };
                    currentCarParts.Add(partCar);
                }
                car.PartCars = currentCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomerDto[] customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach(ImportCustomerDto customerDto in customersDto)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = DateTime.Parse(customerDto.BirthDate),
                    IsYoungDriver = bool.Parse(customerDto.IsYoungDriver)
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }
    }
}