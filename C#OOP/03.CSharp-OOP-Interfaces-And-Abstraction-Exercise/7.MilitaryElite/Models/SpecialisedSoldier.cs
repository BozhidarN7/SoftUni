using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal price,Corps corps)
            : base(id, firstName, lastName, price)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }
    }
}
