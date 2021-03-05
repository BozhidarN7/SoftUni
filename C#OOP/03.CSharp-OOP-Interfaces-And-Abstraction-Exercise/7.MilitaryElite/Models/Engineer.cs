using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Engineer : Private, IEngineer,ISpecialisedSoldier
    {
        private List<IRepair> repairs;
        public Engineer(string id,string firstName,string lastName,decimal salary,Corps corps)
            :base(id,firstName,lastName,salary)
        {
            Corps = corps;
            repairs = new List<IRepair>();
        }
        public IReadOnlyCollection<IRepair> Repairs => repairs.AsReadOnly();

        public Corps Corps { get; private set; }

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corps}");
            result.AppendLine("Repairs:");
            foreach(IRepair repair in repairs)
            {
                result.AppendLine($"  {repair}");
            }
            return result.ToString().Trim();
        }
    }
}
