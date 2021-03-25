using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bender :IBender
{
    public Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public string Name { get; private set; }
    public int Power { get; private set; }
}

