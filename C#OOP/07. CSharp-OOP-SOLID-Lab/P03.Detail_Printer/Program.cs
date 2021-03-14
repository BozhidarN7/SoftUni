using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Manager("Bozhidar",new List<string>(){"something" }),
                new Employee("Ivan")
            };
            DetailsPrinter dp = new DetailsPrinter(employees);
            dp.PrintDetails();
        }
    }
}
