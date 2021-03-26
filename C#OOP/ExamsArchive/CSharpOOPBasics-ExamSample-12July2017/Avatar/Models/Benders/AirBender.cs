using System;
using System.Collections.Generic;
using System.Text;

public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity)
    : base(name, power)
    {
        AerialIntegrity = aerialIntegrity;
    }
    [Element]
    public double AerialIntegrity { get; private set; }
    public override double BenderPower => Power * AerialIntegrity;
}

