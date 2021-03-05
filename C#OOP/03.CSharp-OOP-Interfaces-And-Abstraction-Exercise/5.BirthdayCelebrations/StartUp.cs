using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<IBirthable> byBirthdate = new List<IBirthable>();
            while (line != "End")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    byBirthdate.Add(new Citizen(name, age, id, birthdate));
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    byBirthdate.Add(new Pet(name, birthdate));
                }
                line = Console.ReadLine();
            }
            string year = Console.ReadLine();

            byBirthdate.Where(x => x.Birthdate.EndsWith(year)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
        }
    }
}
