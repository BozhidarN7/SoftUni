namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyImportedDepartmentMessage = "Imported {0} with {1} cells";
        private const string SuccessfullyImportedPrisonerMessage = "Imported {0} {1} years old";
        private const string SuccessfullyImportedOfficerMessage = "Imported {0} ({1} prisoners)";

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
            ImportPrisonerDto[] prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            HashSet<Prisoner> prisoners = new HashSet<Prisoner>();
            StringBuilder result = new StringBuilder();

            foreach (ImportPrisonerDto prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool areAllMeilsValid = true;
                HashSet<Mail> mails = new HashSet<Mail>();
                foreach (ImportPrisonerEmailsDto mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        areAllMeilsValid = false;
                        break;
                    }

                    mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                    });
                }

                if (!areAllMeilsValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrWhiteSpace(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;

                    }
                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = mails
                };

                prisoners.Add(prisoner);
                result.AppendLine(string.Format(SuccessfullyImportedPrisonerMessage, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerPrisonerDto[]), xmlRoot);

            StringReader sr = new StringReader(xmlString);

            ImportOfficerPrisonerDto[] officersDto = (ImportOfficerPrisonerDto[])xmlSerializer.Deserialize(sr);

            StringBuilder result = new StringBuilder();
            HashSet<Officer> officers = new HashSet<Officer>();

            foreach (ImportOfficerPrisonerDto officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (officerDto.Money < 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPositionValid = Enum.TryParse(officerDto.Position, out Position position);
                if (!isPositionValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isWeaponValid = Enum.TryParse(officerDto.Weapon, out Weapon weapon);
                if (!isWeaponValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners.Select(p => new OfficerPrisoner()
                    {
                        PrisonerId = int.Parse(p.Id),
                    })
                    .ToHashSet()
                };

                officers.Add(officer);
                result.AppendLine(string.Format(SuccessfullyImportedOfficerMessage, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
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