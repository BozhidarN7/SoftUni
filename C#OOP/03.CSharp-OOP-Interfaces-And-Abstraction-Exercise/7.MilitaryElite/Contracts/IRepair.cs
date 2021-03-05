using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}
