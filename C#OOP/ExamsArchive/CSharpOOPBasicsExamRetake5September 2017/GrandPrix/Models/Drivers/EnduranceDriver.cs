

public class EnduranceDriver : Driver
{
    private const double EnduranceDriverFuelConsumptionPerKm = 1.5;
    public EnduranceDriver(string name, Car car)
        : base(name, car, EnduranceDriverFuelConsumptionPerKm)
    {
    }
}
