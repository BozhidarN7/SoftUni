using System;
using System.Collections.Generic;
using System.Text;

interface IDriverFactory
{
    public Driver CreateDriver(string type,string name, Car car);
}

