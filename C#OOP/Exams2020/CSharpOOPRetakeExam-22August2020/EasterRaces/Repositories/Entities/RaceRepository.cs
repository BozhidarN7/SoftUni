using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
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
            if (races.ContainsKey(race.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, race.Name));
            }
            races.Add(race.Name, race);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races.Values.ToList().AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            if (races.ContainsKey(name))
            {
                return races[name];
            }
            return null;
        }

        public bool Remove(IRace race)
        {
            return races.Remove(race.Name);
        }
    }
}
