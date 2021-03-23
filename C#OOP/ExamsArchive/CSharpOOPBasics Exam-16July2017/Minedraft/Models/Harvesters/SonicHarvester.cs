using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        SonicFactor = sonicFactor;
        EnergyRequirement /= SonicFactor;
    }
    public int SonicFactor { get; private set; }
}


