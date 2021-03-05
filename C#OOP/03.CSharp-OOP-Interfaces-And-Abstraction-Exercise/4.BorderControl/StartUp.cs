using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifiable> byIds = new List<IIdentifiable>();
            while (input != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    byIds.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    byIds.Add(new Robot(model, id));
                }
                input = Console.ReadLine();
            }
            string lastDigits = Console.ReadLine();

            byIds
              .Where(x => x.Id.EndsWith(lastDigits))
              .ToList()
              .ForEach(x => Console.WriteLine(x.Id));
        }
    }
}
