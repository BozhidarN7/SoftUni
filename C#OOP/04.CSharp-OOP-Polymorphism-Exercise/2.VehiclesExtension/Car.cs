using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double airConditionerModifier = 0.9;
        public Car(double fuelConsumption, double fuelQuantity, double tankCapacity)
            : base(fuelConsumption, fuelQuantity, tankCapacity, airConditionerModifier)
        {
        }
    }
}
