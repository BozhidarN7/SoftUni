using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CompanyRoster
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> workers = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                workers.Add(new Employee(input[0], double.Parse(input[1]), input[2]));
            }

            List<string> departments = workers.Select(x => x.Department).ToList();
            string bestDepartment = string.Empty;
            double highestAverageSalary = 0.0;
            foreach (string department in departments)
            {
                int count = workers.Where(x => x.Department == department).Count();
                double sum = workers.Where(x => x.Department == department).Sum(x => x.Salry);
                double average = sum / count;

                if (average > highestAverageSalary)
                {
                    highestAverageSalary = average;
                    bestDepartment = department;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            workers.Where(x => x.Department == bestDepartment).OrderByDescending(x => x.Salry).ToList().ForEach(x =>
               {
                   Console.WriteLine($"{x.Name} {x.Salry:f2}");
               });
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salry { get; set; }


        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salry = salary;
            Department = department;
        }
    }
}
