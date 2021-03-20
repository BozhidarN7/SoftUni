using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main(string[] args)
    {
        Driver driver = new AggressiveDriver("Bozhidr", new Car(600, 120, new UltrasoftTyre(50,4)));
        Console.WriteLine(driver.GetType().Name);
    }
}

