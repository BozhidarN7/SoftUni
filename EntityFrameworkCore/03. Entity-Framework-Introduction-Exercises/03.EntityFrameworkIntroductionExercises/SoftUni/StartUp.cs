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
                Console.WriteLine(DeleteProjectById(context));

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
        public static string GetEmployee147(SoftUniContext context)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (EmployeeProject ep in employee.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine($"{ep.Project.Name}");
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            List<Department> departments = context.Departments
                 .Where(d => d.Employees.Count > 5)
                 .Include(d => d.Manager)
                 .Include(d => d.Employees)
                 .Take(5)
                 .OrderBy(d => d.Employees.Count)
                 .ThenBy(d => d.Name)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Department department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager?.FirstName} {department.Manager?.LastName}");

                foreach (Employee employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            return string.Join(Environment.NewLine, context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => $"{p.Name}\n{p.Description}\n{p.StartDate.ToString("M/d/yyyy h:mm:ss tt")}"));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<Employee> employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (Employee employee in employees)
            {
                employee.Salary = employee.Salary + employee.Salary * 0.12M;
            }

            context.SaveChanges();

            return string.Join(Environment.NewLine, employees
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})"));
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            return string.Join(Environment.NewLine, context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                .ToList());
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList());
            context.Projects.Remove(context.Projects.Find(2));

            context.SaveChanges();

            return string.Join(Environment.NewLine, context.Projects.Take(10).Select(p => p.Name));
        }
    }
}
