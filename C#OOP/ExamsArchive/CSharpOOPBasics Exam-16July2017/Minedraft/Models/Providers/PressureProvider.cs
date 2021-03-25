using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    private const double EnergyOutputModifier = 0.5;
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {

        EnergyOutput += EnergyOutput * EnergyOutputModifier;
    }
}