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
                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

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

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            return string.Join('\n', context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => $"{e.FirstName} - {e.Salary:f2}")
                .ToList());
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            return string.Join('\n', context.Employees
                .Join(context.Departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    DepartmentName = d.Name
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => $"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}")
                .ToList());
        }

    }
}
