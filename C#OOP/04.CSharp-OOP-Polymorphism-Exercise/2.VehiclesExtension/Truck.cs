using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double airConditionerModifier = 1.6;
        public Truck(double fuelConsumption, double fuelQuantity, double tankCapacity)
            : base(fuelConsumption, fuelQuantity, tankCapacity, airConditionerModifier)
        {
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            FuelQuantity -= (1 - 0.95) * liters;
        }
    }
}
