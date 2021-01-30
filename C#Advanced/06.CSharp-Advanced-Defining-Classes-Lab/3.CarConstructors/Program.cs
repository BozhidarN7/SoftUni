using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Console.WriteLine(car.WhoAmI());
        }
    }
}
