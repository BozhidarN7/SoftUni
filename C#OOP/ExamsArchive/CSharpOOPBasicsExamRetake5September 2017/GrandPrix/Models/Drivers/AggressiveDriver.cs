using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{
    private const double AggressiveDriverFuelConsumptionPerKM = 2.7;
    private const double AggressiveDriverSpeedModifier = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, AggressiveDriverFuelConsumptionPerKM)
    {

    }

    public override double Speed => base.Speed * AggressiveDriverSpeedModifier;
}

