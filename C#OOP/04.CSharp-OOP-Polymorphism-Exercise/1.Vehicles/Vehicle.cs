using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; private set; }

        public abstract string Drive(double distance);
        public abstract void Refuel(double liters);

    }
}

