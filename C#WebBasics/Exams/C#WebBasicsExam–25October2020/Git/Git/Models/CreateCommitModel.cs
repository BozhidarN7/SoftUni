using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models
{
    public class CreateCommitModel
    {
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        public string CreatorId { get; set; }
    }
}
