using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
