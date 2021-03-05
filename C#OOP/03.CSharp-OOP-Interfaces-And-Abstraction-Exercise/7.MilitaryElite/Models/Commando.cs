using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Commando : Private, ICommando, ISpecialisedSoldier
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal price, Corps corps)
            : base(id, firstName, lastName, price)
        {
            Corps = corps;
            missions = new List<IMission>();
        }
        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();

        public Corps Corps { get; private set; }

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corps}");
            result.AppendLine("Missions:");
            foreach(IMission mission in missions)
            {
                result.AppendLine($"  {mission}");
            }
            return result.ToString().Trim();
        }
    }
}
