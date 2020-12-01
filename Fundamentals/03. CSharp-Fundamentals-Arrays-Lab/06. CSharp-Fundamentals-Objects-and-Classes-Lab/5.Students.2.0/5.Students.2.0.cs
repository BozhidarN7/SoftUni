using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _5.Students._2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();

                Student student = students.FirstOrDefault(s => s.FirstName == tokens[0] && s.LastName == tokens[1]);
                
                if (student == null)
                {
                    students.Add(new Student { FirstName = tokens[0], LastName = tokens[1], Age = int.Parse(tokens[2]), HomeTown = tokens[3] });
                }
                else
                {
                    students.Remove(student);
                    student.FirstName = tokens[0];
                    student.LastName = tokens[1];
                    student.Age = int.Parse(tokens[2]);
                    student.HomeTown  = tokens[3];
                    students.Add(student);

                }

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
