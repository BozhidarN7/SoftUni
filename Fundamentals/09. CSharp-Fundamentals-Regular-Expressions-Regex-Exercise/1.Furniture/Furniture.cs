using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1.Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> bought = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                Regex pattern = new Regex(@">>(?<furniture>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)");
                Match match = pattern.Match(input);

                if (match.Success)
                {
                    bought.Add(match.Groups["furniture"].Value);
                    totalPrice += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in bought)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
