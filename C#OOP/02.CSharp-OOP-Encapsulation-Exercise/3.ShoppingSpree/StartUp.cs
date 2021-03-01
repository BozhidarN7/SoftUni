using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    people.Add(tokens[0], new Person(tokens[0], decimal.Parse(tokens[1])));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    products.Add(tokens[0], new Product(tokens[0], decimal.Parse(tokens[1])));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];
                try
                {
                    people[personName].AddProduct(products[productName]);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                line = Console.ReadLine();
            }
            foreach ((string name, Person person) in people)
            {
                if (person.Bag.Count != 0)
                {
                    Console.WriteLine($"{name} - {string.Join(", ", person.Bag.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{name} - Nothing bought");
                }

            }
        }
    }
}
