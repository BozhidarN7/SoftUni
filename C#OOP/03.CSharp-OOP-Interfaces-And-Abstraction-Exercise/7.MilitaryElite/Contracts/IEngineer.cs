using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        public void AddRepair(IRepair repair);
    }
}
