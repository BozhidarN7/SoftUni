using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Model = "M3";
            Console.WriteLine(car.WhoAmI());
        }
    }
}
