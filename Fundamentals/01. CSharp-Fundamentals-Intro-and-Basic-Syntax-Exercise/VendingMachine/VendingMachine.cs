using System;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0.0;

            while (input != "Start")
            {
                double coin = double.Parse(input);
                if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1.0 && coin != 2.0)
                {
                    Console.WriteLine("Cannot accept {0}", coin);
                    input = Console.ReadLine();
                    continue;
                }

                sum += coin;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                if (input != "Nuts" && input != "Water" && input != "Crisps" && input != "Soda" && input != "Coke")
                {
                    Console.WriteLine("Invalid product");
                    input = Console.ReadLine();
                    continue;
                }

                if (input == "Nuts")
                {
                    if (sum < 2)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased nuts");
                        sum -= 2;
                    }
                }
                else if (input == "Water")
                {
                    if (sum < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased water");
                        sum -= 0.7;
                    }
                }
                else if (input == "Crisps")
                {
                    if (sum < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased crisps");
                        sum -= 1.5;
                    }
                }
                else if (input == "Soda")
                {
                    if (sum < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        
                        Console.WriteLine("Purchased soda");
                        sum -= 0.8;
                    }
                }
                else
                {
                    if (sum < 1)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased coke");
                        sum -= 1;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Change: {0:f}", sum);
        }
    }
}
