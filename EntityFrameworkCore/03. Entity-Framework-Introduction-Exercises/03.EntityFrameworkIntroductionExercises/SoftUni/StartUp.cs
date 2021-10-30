using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(GetAddressesByTown(context));

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

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            EntityEntry<Address> newAddress1 = context.Addresses.Add(new Address() { AddressText = "Vitoshka 15", TownId = 4 });

            Employee employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            employee.Address = newAddress1.Entity;

            context.SaveChanges();

            return String.Join(Environment.NewLine, context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10).Select(e => e.Address.AddressText)
                .ToList());
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            List<Employee> employees = context.Employees
                .Include(x => x.Manager)
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (EmployeeProject ep in employee.EmployeesProjects)
                {
                    sb.AppendLine($"--{ep.Project.Name} -" +
                                  $" {ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                  $"{(ep.Project.EndDate == null ? "not finished" : ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            return string.Join(Environment.NewLine, context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));


        }
    }
}
