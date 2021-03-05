using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    public interface ICommando
    {
        public IReadOnlyCollection<IMission> Missions { get; }
        public void AddMission(IMission mission);
    }
}
