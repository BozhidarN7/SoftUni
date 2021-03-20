using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private const string DefaultName = "Ultrasoft";
    public UltrasoftTyre(double hardness, double grip)
        : base(DefaultName, hardness)
    {
        Grip = grip;
    }
    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Tyre blows up");
            }
            Degradation = value;
        }
    }
    public double Grip { get; set; }
    public override void Degradate()
    {
        Degradation -= Hardness + Grip;
    }
}

