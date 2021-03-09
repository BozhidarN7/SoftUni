using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    interface IVehicle
    {
        public string Drive(double distance);
        public void Refuel(double liters);
    }
}
