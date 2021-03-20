using System;
using System.Collections.Generic;
using System.Text;


public class TyreFactory : ITyreFactory
{
    public Tyre CreateTyre(string name, double hardness,int grip)
    {
        if (name == "Ultfasoft")
        {
            return new UltrasoftTyre(hardness,grip);
        }
        else if(name == "HardTyre")
        {
            return new HardTyre(hardness);
        }
        return null;
    }
}

