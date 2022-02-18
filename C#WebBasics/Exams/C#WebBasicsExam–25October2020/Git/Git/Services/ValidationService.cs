using Git.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class ValidationService : IValidationService
    {
        public (bool isValid, string error) ValidateModel(object model)
        {
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> errors = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errors, true);

            if (isValid)
            {
                return (isValid, null);
            }

            return (isValid, string.Join(", ", errors.Select(e => e.ErrorMessage)));
        }
    }
}
