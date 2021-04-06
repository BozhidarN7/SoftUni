using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private Dictionary<string, IRace> races;

        public RaceRepository()
        {
            races = new Dictionary<string, IRace>();
        }
        public void Add(IRace race)
        {
            races.Add(race.Name, race);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races.Values.ToList().AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return races[name];
        }

        public bool Remove(IRace race)
        {
            return races.Remove(race.Name);
        }
    }
}
