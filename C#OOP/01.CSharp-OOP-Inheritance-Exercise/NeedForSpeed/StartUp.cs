using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(130, 40);
            car.Drive(10);
            Console.WriteLine(car.Fuel);

            SportCar sportCar = new SportCar(600, 50);
            Console.WriteLine(sportCar.FuelConsumption);
        }
    }
}
