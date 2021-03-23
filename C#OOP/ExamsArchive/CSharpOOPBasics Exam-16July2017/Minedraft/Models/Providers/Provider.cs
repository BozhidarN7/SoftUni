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
        this.energyOutput = energyOutput;
    }
    public string Id { get; private set; }

    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            if (value < MinEnergyOutput)
            {
                throw new ArgumentException("invalid command");
            }
            if (value > MaxEnergyOutput)
            {
                throw new ArgumentException("Invalid command");
            }
            energyOutput = value;
        }
    }
}

