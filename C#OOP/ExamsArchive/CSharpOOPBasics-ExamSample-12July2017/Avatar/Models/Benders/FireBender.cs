using System;
using System.Collections.Generic;
using System.Text;

public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        HeatAggression = heatAggression;
    }
    [Element]
    public double HeatAggression { get; private set; }
    public override double BenderPower => Power * HeatAggression;
}


