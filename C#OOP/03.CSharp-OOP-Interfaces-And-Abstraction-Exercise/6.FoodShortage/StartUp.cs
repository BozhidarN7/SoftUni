using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.FoodShortage
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> byName = new Dictionary<string, Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    byName.Add(name, new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group= tokens[2];
                    byName.Add(name, new Rebel(name, age, group));
                }
            }
            string input = Console.ReadLine();
            while(input != "End")
            {
                if (!byName.ContainsKey(input))
                {
                    input = Console.ReadLine();
                    continue;
                }
                byName[input].BuyFood();
                input = Console.ReadLine();
            }
            Console.WriteLine(byName.Values.Sum(x => x.Food));
        }
    }
}
