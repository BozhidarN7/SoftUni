public abstract class Driver
{
    public Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        Name = name;
        Car = car;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }
    public string Name { get; private set; }
    public double TotalTime { get; set; }
    public Car Car { get; private set; }
    public double FuelConsumptionPerKm { get; private set; }
    public int Position { get; set; }
    public virtual double Speed => (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
    public override string ToString()
    {
        return $"{Name}";
    }
}

