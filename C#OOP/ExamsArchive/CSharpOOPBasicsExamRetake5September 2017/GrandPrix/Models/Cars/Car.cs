using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    private const double FuelAmountCapacity = 160;
    private double fuelAmount;
    public int Hp { get; private set; }
    public double FuelAmount
    {
        get => fuelAmount;
        set
        {
            if (value > FuelAmountCapacity)
            {
                fuelAmount = FuelAmountCapacity;
            }
            if (value <= 0)
            {
                throw new ArgumentException(ConstantMessages.OutOfFuel);
            }
            fuelAmount = value;
        }
    }
    public Tyre Tyre { get; set; }
}

