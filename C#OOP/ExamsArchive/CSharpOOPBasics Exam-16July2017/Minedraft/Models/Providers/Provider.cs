using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider
{
    private const int MinEnergyOutput = 0;
    private const int MaxEnergyOutput = 10000;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }
    public string Id { get; private set; }

    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            if (value < MinEnergyOutput)
            {
                throw new ArgumentException("EnergyOutput");
            }
            if (value > MaxEnergyOutput)
            {
                throw new ArgumentException("EnergyOutput");
            }
            energyOutput = value;
        }
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        string type = GetType().Name;
        int index = type.IndexOf("Provider");

        result.AppendLine($"{type.Remove(index)} Provider - {Id}");
        result.AppendLine($"Energy Output: {EnergyOutput}");
        return result.ToString().TrimEnd();
    }
}

