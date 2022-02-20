using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.ViewModels.ImportModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email must be valid email")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and Confirm password must be eqaul")]
        public string ConfirmPassword { get; set; }
    }
}
