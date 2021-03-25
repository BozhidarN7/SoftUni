using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester
{
    private const int MinOreOutput = 0;
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20000;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }
    public string Id { get; private set; }
    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            if (value < MinOreOutput)
            {
                throw new ArgumentException("OreOutput");
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
                throw new ArgumentException("EnergyRequirement");
            }
            if (value > MaxEnergyRequirement)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            energyRequirement = value;
        }
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        string type = GetType().Name;
        int index = type.IndexOf("Harvester");

        result.AppendLine($"{type.Remove(index)} Harvester - {Id}");
        result.AppendLine($"Ore Output: {OreOutput}");
        result.AppendLine($"Energy Requirement: {EnergyRequirement}");
        return result.ToString().TrimEnd();
    }
}

