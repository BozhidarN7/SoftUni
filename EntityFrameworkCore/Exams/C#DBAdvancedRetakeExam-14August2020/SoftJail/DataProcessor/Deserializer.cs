namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyImportedDepartmentMessage = "Imported {0} with {1} cells";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            ImportDepartmentDto[] departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            HashSet<Department> departments = new HashSet<Department>();
            StringBuilder result = new StringBuilder();
            foreach (ImportDepartmentDto departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (departmentDto.Cells.Length == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool areAllCellsValid = true;
                HashSet<Cell> cells = new HashSet<Cell>();
                foreach (ImportDepartmentCellDto cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        areAllCellsValid = false;
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                    };

                    cells.Add(cell);
                }

                if (!areAllCellsValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name,
                    Cells = cells
                };

                departments.Add(department);
                result.AppendLine(string.Format(SuccessfullyImportedDepartmentMessage, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return result.ToString().TrimEnd();

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}