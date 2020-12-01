using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i< n; i++)
            {
                string[] input = Console.ReadLine().Split();
                students.Add(new Student(input[0], input[1], double.Parse(input[2])));
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName , string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
