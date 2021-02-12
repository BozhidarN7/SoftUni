using System;
using System.Collections.Generic;

namespace _6.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hasSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                hasSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hasSet.Count);
        }
    }
}
