using System;
using System.Collections.Generic;
using System.Text;

public class SolarProvider : Provider
{
    private const double EnergyOutputModifier = 0.5;
    public SolarProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        EnergyOutput += EnergyOutput * EnergyOutputModifier;
    }
}

