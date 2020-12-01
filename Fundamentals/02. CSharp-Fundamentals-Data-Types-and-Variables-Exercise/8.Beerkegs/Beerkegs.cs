using System;
using System.Security;

namespace _8.Beerkegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string bestModel = "";
            double deepestKeg = double.MinValue;
            for (int i = 0; i < n ; i++)
            {
                string model = Console.ReadLine();
                double radious = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = radious * radious * height;
                if (volume > deepestKeg)
                {
                    deepestKeg = volume;
                    bestModel = model;
                }
            }
            Console.WriteLine(bestModel);
        }
    }
}
