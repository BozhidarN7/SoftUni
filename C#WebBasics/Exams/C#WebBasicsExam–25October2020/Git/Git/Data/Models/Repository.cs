using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            Id = Guid.NewGuid().ToString();
            Commits = new HashSet<Commit>();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublick { get; set; }

        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }

        public User owner { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
