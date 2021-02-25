using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Coffee coffe = new Coffee("capacino", 20);
            HotBeverage hot = new HotBeverage("something", 20, 20);
            coffe.Price = 50;
            Console.WriteLine(coffe.Price);
        }
    }
}