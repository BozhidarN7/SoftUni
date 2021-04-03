using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private const int MinCapacity = 0;
        private const int MinNumberOfPeople = 0;

        private int capacity;
        private int numberOfPeople;

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= MinCapacity)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= MinNumberOfPeople)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; } = false;

        public decimal Price => PricePerPerson * NumberOfPeople;
        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price) + Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Table: {TableNumber}");
            result.AppendLine($"Type: {GetType().Name}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Price per Person: {PricePerPerson:f2}");

            return result.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
