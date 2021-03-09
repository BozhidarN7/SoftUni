using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditioningBonus = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override string Drive(double distance)
        {
            if (FuelQuantity - FuelConsumption * distance - distance * AirConditioningBonus < 0)
            {
                return $"{GetType().Name} needs refueling";
            }
            FuelQuantity -= (FuelConsumption * distance + distance * AirConditioningBonus);
            return $"{GetType().Name} travelled {distance} km";
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
