using System;

namespace _2.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info

                .Built
                .InCity("Leipzig")
                .AtAddress("Some address 245")
            .Build();

            Console.WriteLine(car);
        }
    }
}
