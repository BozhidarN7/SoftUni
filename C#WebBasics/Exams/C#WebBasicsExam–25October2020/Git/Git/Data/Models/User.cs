using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Repositories = new HashSet<Repository>();
            Commits = new HashSet<Commit>();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get;set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get;set; }

        public ICollection<Repository> Repositories { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
