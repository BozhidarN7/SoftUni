using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
   public  class RaceMotorcycle :Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption { get; set; } = 8;

        public override void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
            if (Fuel < 0)
            {
                Fuel = 0;
            }
        }
    }
}
