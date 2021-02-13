using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car is null)
            {
                return false;
            }
            data.Remove(car);
            return true;
        }
        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");
            result.AppendLine(string.Join(Environment.NewLine, data));
            return result.ToString();
        }
    }
}
