using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    private const int OreOutputModifier = 2;
    private const int EnergyRequirementModifier = 1;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        OreOutput += OreOutput * OreOutputModifier;
        EnergyRequirement += EnergyRequirement * EnergyRequirementModifier;
    }
}
