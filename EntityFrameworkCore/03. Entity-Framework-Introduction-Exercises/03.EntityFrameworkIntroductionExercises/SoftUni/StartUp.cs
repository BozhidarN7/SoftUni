using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesFullInformation(context));
                Employee employee = context.Employees.Where(e => e.EmployeeId == 292).FirstOrDefault();
                Console.WriteLine(employee.MiddleName);
                Console.WriteLine(employee.MiddleName == null);
            }
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            return string.Join('\n', context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    EmployeeInfo = $"{e.FirstName} {e.LastName}{(e.MiddleName == null || e.MiddleName == String.Empty ? " " : $" {e.MiddleName} ")}{e.JobTitle} {e.Salary:f2}",
                })
                .OrderBy(e => e.Id)
                .Select(e => e.EmployeeInfo)
                .ToList());
        }

    }
}
