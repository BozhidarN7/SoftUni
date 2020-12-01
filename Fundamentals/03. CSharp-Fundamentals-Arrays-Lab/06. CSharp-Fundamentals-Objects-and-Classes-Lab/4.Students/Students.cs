using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Students
{
    class Students
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();

                students.Add(new Student { FirstName = tokens[0], LastName = tokens[1], Age = int.Parse(tokens[2]), HomeTown = tokens[3] });

                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            students.Where(x => x.HomeTown == town).ToList().ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} is {x.Age} years old."));
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string HomeTown { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
