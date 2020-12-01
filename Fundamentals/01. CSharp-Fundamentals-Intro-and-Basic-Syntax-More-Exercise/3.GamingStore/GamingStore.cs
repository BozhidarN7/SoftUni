using System;

namespace _3.GamingStore
{
    class GamingStore
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double totalSpent = 0.0;
            while (input != "Game Time")
            {
                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                if (input == "OutFall 4")
                {
                    if (budget >= 39.99)
                    {
                        budget -= 39.99;
                        totalSpent += 39.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "CS: OG")
                {
                    if (budget >= 15.99)
                    {
                        budget -= 15.99;
                        totalSpent += 15.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Zplinter Zell")
                {
                    if (budget >= 19.99)
                    {
                        budget -= 19.99;
                        totalSpent += 19.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Honored 2")
                {
                    if (budget >= 59.99)
                    {
                        budget -= 59.99;
                        totalSpent += 59.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch")
                {
                    if (budget >= 29.99)
                    {
                        budget -= 29.99;
                        totalSpent += 29.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    if (budget >= 39.99)
                    {
                        budget -= 39.99;
                        totalSpent += 39.99;
                        Console.WriteLine($"Bought {input}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                input = Console.ReadLine();
            }

            if (budget == 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${budget:f2}");
            }
        }
    }
}
