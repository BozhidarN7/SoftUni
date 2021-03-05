using _7.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal price)
            : base(id, firstName, lastName)
        {
            Salary = price;
        }
        public decimal Salary { get; private set; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
