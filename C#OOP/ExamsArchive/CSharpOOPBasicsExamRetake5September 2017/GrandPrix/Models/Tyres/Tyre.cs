using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    private const double InitialDegradation = 100;
    private double degradation;

    public Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        degradation = InitialDegradation;
    }
    public string Name { get; private set; }
    public double Hardness { get; private set; }
    public virtual double Degradation
    {
        get => degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(ConstantMessages.BlownTyre);
            }
            degradation = value;
        }
    }
    public virtual void Degradate()
    {
        Degradation -= Hardness;
    }
}

