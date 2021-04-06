using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private Dictionary<string, ICar> cars;

        public CarRepository()
        {
            cars = new Dictionary<string, ICar>();
        }
        public void Add(ICar car)
        {
            if (cars.ContainsKey(car.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, car.Model));
            }
            cars.Add(car.Model, car);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars.Values.ToList().AsReadOnly();
        }

        public ICar GetByName(string model)
        {
            if (cars.ContainsKey(model))
            {
                return cars[model];
            }
            return null;
        }

        public bool Remove(ICar car)
        {
           return cars.Remove(car.Model);
        }
    }
}
