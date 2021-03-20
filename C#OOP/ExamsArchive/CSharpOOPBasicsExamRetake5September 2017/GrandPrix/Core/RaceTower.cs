using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class RaceTower
{
    private int lapsNumber;
    private int lapsLeft;
    private int trackLength;
    private List<Driver> drivers;
    public List<Driver> outOfRaceDrivers;
    private readonly IDriverFactory driverFactory;
    private readonly ITyreFactory tyreFactory;
    private Weather weather;
    public RaceTower()
    {
        drivers = new List<Driver>();
        outOfRaceDrivers = new List<Driver>();
        driverFactory = new DriverFactory();
        tyreFactory = new TyreFactory();
    }
    private Driver FindDriver(string driverName)
    {
        return drivers.FirstOrDefault(x => x.Name == driverName);
    }
    /*private string Overtake()
    {
        foreach (Driver driver in drivers.OrderBy(x => x.TotalTime))
        {
            if (driver.GetType().Name == "AggressiveDriver" && driver.Car.Tyre.GetType().Name =="UltrasoftTyre")
            {
                Driver driverAhead = drivers.FirstOrDefault(x => driver.TotalTime - x.TotalTime <= 3);
            }
            else if(driver.GetType().Name == "EnduranceDriver" && driver.Car.Tyre.GetType)
        }
    }*/
    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
        lapsLeft = lapsNumber;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        string driverType = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);
        int grip = 0;
        if (commandArgs.Count > 6)
        {
            grip = int.Parse(commandArgs[6]);
        }
        Tyre tyre = tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
        Car car = new Car(hp, fuelAmount, tyre);
        Driver driver = driverFactory.CreateDriver(driverType, name, car);
        drivers.Add(driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = FindDriver(driverName);

        if (reasonToBox == "ChangeTyres")
        {
            string tyreType = commandArgs[2];
            double tyreHardness = double.Parse(commandArgs[3]);
            if (tyreType == "Ultrasoft")
            {
                double grip = double.Parse(commandArgs[4]);
                driver.Car.Tyre = new UltrasoftTyre(tyreHardness, grip);
            }
            else
            {
                driver.Car.Tyre = new HardTyre(tyreHardness);
            }
        }
        else if (reasonToBox == "Refuel")
        {
            double Refuel = double.Parse(commandArgs[2]);
            driver.Car.FuelAmount += Refuel;
        }
    }


    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > lapsLeft)
        {
            throw new ArgumentException("There are less remaing laps");
        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            foreach (Driver driver in drivers)
            {
                try
                {
                    driver.TotalTime += 60 / (trackLength / driver.Speed);
                    driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                    driver.Car.Tyre.Degradate();
                }
                catch (ArgumentException ex)
                {
                    outOfRaceDrivers.Add(driver);
                    drivers.Remove(driver);
                }
            }
            lapsNumber--;
            //string resultOfOvertake = Overtake();
        }
        return "";
    }

    public string GetLeaderboard()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{lapsNumber - lapsLeft}/{lapsNumber}");
        foreach (Driver driver in drivers.OrderBy(x => x.TotalTime))
        {
            result.Append(driver);
        }
        return result.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherAsString = commandArgs[0];
        Enum.TryParse(weatherAsString, out Weather newWeather);
        weather = newWeather;
    }

}

