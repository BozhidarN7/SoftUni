using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models
{
    public class CreateRepositoryModel
    {
        [StringLength(10, MinimumLength = 3 , ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }
        
        public string RepositoryType { get; set; }
    }
}
