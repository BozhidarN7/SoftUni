using System;
using System.Collections.Generic;
using System.Text;


public interface ITyreFactory
{
    public Tyre CreateTyre(string name, double hardness,int grip);
}

