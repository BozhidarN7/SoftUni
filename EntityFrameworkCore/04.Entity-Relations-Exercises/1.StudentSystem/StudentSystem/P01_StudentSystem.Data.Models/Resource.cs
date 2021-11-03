using P01_StudentSystem.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int RecourseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(2048)]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
    }
}
