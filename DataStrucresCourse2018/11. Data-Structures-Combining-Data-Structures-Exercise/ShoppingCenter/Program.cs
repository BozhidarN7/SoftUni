using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int commandsNumber = int.Parse(Console.ReadLine());
        ShoppingCenter center = new ShoppingCenter();

        for (int i = 0; i < commandsNumber; i++)
        {
            string line = Console.ReadLine();
            int firstSpace = line.IndexOf(" ");

            string command = line.Substring(0, firstSpace);
            string[] tokens = line.Substring(firstSpace + 1).Split(';');


            switch (command)
            {
                case "AddProduct":
                    {
                        string name = tokens[0];
                        double price = double.Parse(tokens[1]);
                        string producer = tokens[2];

                        Product p = new Product(name, price, producer);
                        center.Add(p);
                        Console.WriteLine("Product added");
                        break;
                    }
                case "DeleteProducts":
                    if (tokens.Length == 1)
                    {
                        int count = center.DeleteProductsByProducer(tokens[0]);

                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count.ToString() + " products deleted");
                        }
                    }
                    else
                    {
                        int count = center.DeleteProductsByProducerAndName(
                            tokens[0],
                            tokens[1]);
                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count.ToString() + " products deleted");
                        }
                    }
                    break;

                case "FindProductsByName":

                    List<Product> result =
                        center.FindProductsByName(tokens[0]).ToList();
                    if (result.Count != 0)
                    {
                        Console.WriteLine(string.Join("\n", result));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;

                case "FindProductsByProducer":
                    List<Product> result2 =
                        center.FindProductsByProducer(tokens[0]).ToList();

                    if (result2.Count != 0)
                    {
                        Console.WriteLine(string.Join("\n", result2));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }

                    break;

                case "FindProductsByPriceRange":
                    IEnumerable<Product> result3 =
                        center.FindProductsByPriceRange(
                                double.Parse(tokens[0]),
                                double.Parse(tokens[1]))
                            .OrderBy(x => x);

                    if (result3.Any())
                    {
                        Console.WriteLine(string.Join("\n", result3));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
            }
        }
    }
}


