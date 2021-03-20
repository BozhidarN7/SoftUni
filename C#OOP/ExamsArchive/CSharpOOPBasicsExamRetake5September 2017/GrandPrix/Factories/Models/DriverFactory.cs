using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class DriverFactory : IDriverFactory
{
    Driver IDriverFactory.CreateDriver(string type, string name, Car car)
    {
        if (type == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }
        return null;
    }
}

