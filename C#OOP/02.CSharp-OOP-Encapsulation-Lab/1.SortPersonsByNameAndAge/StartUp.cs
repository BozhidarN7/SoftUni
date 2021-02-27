using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(input[0], input[1], int.Parse(input[2])));

            }
            people.OrderBy(x => x.FirstName).ThenBy(x => x.Age).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
