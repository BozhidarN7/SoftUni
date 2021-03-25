using System;
using System.Collections.Generic;
using System.Text;

public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; private set; }
}

