using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input !="End")
            {
                string[] tokens = input.Split();

                people.Add(new Person(tokens[0], tokens[1], int.Parse(tokens[2])));

                input = Console.ReadLine();
            }

            people.OrderBy(x => x.Age).ToList().ForEach(x =>
             {
                 Console.WriteLine($"{x.Name} with ID: {x.ID} is {x.Age} years old.");
             });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            Age = age;
            ID = id;
        }
    }
}
