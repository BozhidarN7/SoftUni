using System;
using System.Collections.Generic;
using System.Text;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        GroundSaturation = groundSaturation;
    }
    [Element]
    public double GroundSaturation { get; private set; }
    public override double BenderPower => Power * GroundSaturation;
}


