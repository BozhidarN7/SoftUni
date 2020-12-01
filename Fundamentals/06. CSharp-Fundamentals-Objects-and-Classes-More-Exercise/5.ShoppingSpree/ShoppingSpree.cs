using System;
using System.Collections.Generic;


namespace _5.ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] input = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split('=');
                people.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            input = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split('=');
                products.Add(new Product(tokens[0], int.Parse(tokens[1])));
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] tokens = line.Split();

                int personIndex = people.FindIndex(x => x.Name == tokens[0]);
                int productIndex = products.FindIndex(x => x.Name == tokens[1]);

                if (people[personIndex].Money >= products[productIndex].Cost)
                {
                    people[personIndex].Products.Add(tokens[1]);
                    people[personIndex].Money -= products[productIndex].Cost;
                    Console.WriteLine($"{tokens[0]} bought {tokens[1]}");
                }
                else
                {
                    Console.WriteLine($"{tokens[0]} can't afford {tokens[1]}");
                }

                line = Console.ReadLine();
            }

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Products.Count==0)
                {
                    Console.WriteLine($"{people[i].Name} - Nothing bought");
                    continue;
                }

                Console.Write($"{people[i].Name} - ");
                for (int j = 0; j < people[i].Products.Count; j++)
                {
                    if(j == people[i].Products.Count-1)
                    {
                        Console.Write($"{people[i].Products[j]}");
                    }
                    else
                    {
                        Console.Write($"{people[i].Products[j]}, ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> Products { get; set; }
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Products = new List<string>();
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
