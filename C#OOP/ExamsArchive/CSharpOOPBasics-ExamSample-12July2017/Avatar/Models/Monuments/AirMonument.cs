using System;
using System.Collections.Generic;
using System.Text;

public class AirMonument : Monument
{
    public AirMonument(string name,int airAffinity)
        : base(name)
    {
        AirAffinity = airAffinity;
    }

    public int AirAffinity { get; private set; }
}

