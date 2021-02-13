using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);
            if (!(pet is null))
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("The clinic has the following patients:");
            result.AppendLine(string.Join(Environment.NewLine, data.Select(x => $"Pet {x.Name} with owner: {x.Owner}")));
            return result.ToString();
        }
    }
}
