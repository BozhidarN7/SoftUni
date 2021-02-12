using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        private readonly List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;
        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            int removed =data.RemoveAll(x => x.Name == name);
            if (removed > 0)
            {
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report() 
        {
            return $"Employees working at Bakery {Name}:{Environment.NewLine}" + string.Join(Environment.NewLine, data.Select(x => x.ToString()));
        }

    }
}
