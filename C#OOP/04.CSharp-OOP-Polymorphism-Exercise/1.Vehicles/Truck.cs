using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditioningBonus = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
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
            FuelQuantity += liters * 0.95;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
