using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre : Tyre
{
    private const string DefaultName = "Hard";
    public HardTyre(double hardness)
        : base(DefaultName, hardness)
    {
    }
}

