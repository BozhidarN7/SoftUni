using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
                input = Console.ReadLine();
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            int same = 0;
            for (int i = 0; i < people.Count; i++)
            {
                if (i != index && people[index].CompareTo(people[i]) == 0)
                {
                    same++;
                }
            }
            if (same == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                same += 1;
                Console.WriteLine($"{same} {people.Count -same} {people.Count}");
            }
        }
    }
}
