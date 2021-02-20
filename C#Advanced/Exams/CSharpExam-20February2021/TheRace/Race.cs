using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            int removed = data.RemoveAll(x => x.Name == name);
            if (removed == 0)
            {
                return false;
            }
            return true;
        }
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }
        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            return $"Racers participating at {Name}:{Environment.NewLine}{string.Join(Environment.NewLine,data)}";

        }
    }
}
