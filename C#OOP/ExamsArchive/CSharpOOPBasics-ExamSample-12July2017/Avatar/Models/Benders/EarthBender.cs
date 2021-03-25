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
    public double GroundSaturation { get; private set; }
}


