using System;
using System.Collections.Generic;
using System.Text;

public class WaterBender : Bender
{
    public WaterBender(string name, int power,double waterClarity)
        : base(name, power)
    {
        WaterClarity = waterClarity;
    }

    public double WaterClarity { get; private set; }
}

