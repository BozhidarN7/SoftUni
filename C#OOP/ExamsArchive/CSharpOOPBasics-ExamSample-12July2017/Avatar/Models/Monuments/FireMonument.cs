using System;
using System.Collections.Generic;
using System.Text;


public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        FireAffinity = fireAffinity;
    }
    [Element]
    public int FireAffinity { get; private set; }
}

