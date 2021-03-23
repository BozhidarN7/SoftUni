using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester
{
    private const int MinOreOutPut = 0;
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20000;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        this.oreOutput = oreOutput;
        this.energyRequirement = energyRequirement;
    }
    public string Id { get; private set; }
    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            if (value < MinOreOutPut)
            {
                throw new ArgumentException("OreOutput cannot be negative");
            }
            oreOutput = value;
        }
    }
    public double EnergyRequirement
    {
        get => energyRequirement;
        protected set
        {
            if (value < MinEnergyRequirement)
            {
                throw new ArgumentException("Invalid command");
            }
            if (value > MaxEnergyRequirement)
            {
                throw new ArgumentException("Invalid command");
            }
            energyRequirement = value;
        }
    }

}

