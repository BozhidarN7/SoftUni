using _7.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(string id,string firstName,string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
