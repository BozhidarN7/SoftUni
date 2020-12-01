using System;
using System.Text.RegularExpressions;

namespace _3.SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$");
            double totalPrice = 0;
            while (input != "end of shift")
            {
                Match match = pattern.Match(input);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string prodcut = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value);
                    Console.WriteLine($"{name}: {prodcut} - {price:f2}");
                        
                    totalPrice += price;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Total income: {0:f2}", totalPrice);

        }
    }
}
