using _7.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }
        public MissionState MissionState { get; }
        public void CompleteMission();
    }
}
