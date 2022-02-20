using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.ImportModels
{
    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get;set; }

        [Range(0, 10)]
        public byte Speed { get; set; }

        [Range(0,10)]
        public byte Endurance { get;set; }

        [Required]
        [MaxLength(200, ErrorMessage = "{0} must be at most {1} characters")]
        public string Description { get; set; }
    }
}
