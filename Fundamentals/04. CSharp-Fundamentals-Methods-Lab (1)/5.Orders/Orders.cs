using System;

namespace _5.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateTotalPrice(product, quantity);

        }

        private static void CalculateTotalPrice(string product, int quantity)
        {
            if (product =="coffee")
            {
                Console.WriteLine($"{1.50 * quantity:f2}");
            }
            else if (product == "water")
            {
                Console.WriteLine($"{1.00 * quantity:f2}");
            }
            else if (product == "coke")
            {
                Console.WriteLine($"{1.40 * quantity:f2}");
            }
            else if (product == "snacks")
            {
                Console.WriteLine($"{2.00 * quantity:f2}");
            }
        }
    }
}
