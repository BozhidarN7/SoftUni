using System;
using System.Collections.Generic;
using System.Text;

public class AirBender : Bender
{
    public AirBender(string name, int power,double aerialIntegrity)
    : base(name, power)
    {
        AerialIntegrity = aerialIntegrity;
    }
    public double AerialIntegrity { get; private set; }
}

