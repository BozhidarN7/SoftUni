namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportProjectDto[] projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(sr);

            ICollection<Project> projects = new HashSet<Project>();
            StringBuilder result = new StringBuilder();
            foreach (ImportProjectDto projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InstalledUICulture, DateTimeStyles.None, out DateTime openDate);

                if (!isOpenDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {

                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InstalledUICulture, DateTimeStyles.None, out DateTime dueDateValue);

                    if (!isDueDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                if (!IsValid(project))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Task> tasks = new HashSet<Task>();

                foreach (ImportTaskDto taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InstalledUICulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                      CultureInfo.InstalledUICulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (project.DueDate.HasValue && taskDueDate > project.DueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    };

                    tasks.Add(task);
                }
                project.Tasks = tasks;
                projects.Add(project);

                result.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportEmployeeDto[] employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            StringBuilder result = new StringBuilder();

            ICollection<Employee> employees = new HashSet<Employee>();

            foreach (ImportEmployeeDto employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                HashSet<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();
                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.Find(taskId);

                    if (task == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskId
                    };

                    employeeTasks.Add(employeeTask);
                }

                employee.EmployeesTasks = employeeTasks;
                employees.Add(employee);

                result.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employeeTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}