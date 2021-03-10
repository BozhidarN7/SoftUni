using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;

        }
        protected double AirConditionerModifier { get; set; }
        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity - FuelConsumption * distance - distance * AirConditionerModifier < 0)
            {
                return $"{GetType().Name} needs refueling";
            }
            FuelQuantity -= (FuelConsumption * distance + distance * AirConditionerModifier);
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }

            double addedFuel = FuelQuantity + liters;
            if (addedFuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
