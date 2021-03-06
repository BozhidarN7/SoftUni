﻿using System;
using System.Collections.Generic;
using System.Text;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        WaterAffinity = waterAffinity;
    }
    [Element]
    public int WaterAffinity { get; private set; }
}
