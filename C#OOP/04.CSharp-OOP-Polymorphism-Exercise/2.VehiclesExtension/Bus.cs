using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double airConditionerModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, airConditionerModifier)
        {
        }
        public void TurnOnAirConditioner()
        {
            AirConditionerModifier = airConditionerModifier;
        }
        public void TurnOffAirConditioner()
        {
            AirConditionerModifier = 0;
        }
    }
}
