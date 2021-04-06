using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private Dictionary<string, IDriver> drivers;

        public DriverRepository()
        {
            drivers = new Dictionary<string, IDriver>();
        }
        public void Add(IDriver driver)
        {
            drivers.Add(driver.Name,driver);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers.Values.ToList().AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return drivers[name];
        }

        public bool Remove(IDriver driver)
        {
            return drivers.Remove(driver.Name);
        }
    }
}
