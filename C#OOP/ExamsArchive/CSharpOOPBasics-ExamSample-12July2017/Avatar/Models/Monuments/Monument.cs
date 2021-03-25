using System;
using System.Collections.Generic;
using System.Text;

public abstract class Monument : IMonument
{
    public Monument(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
}

