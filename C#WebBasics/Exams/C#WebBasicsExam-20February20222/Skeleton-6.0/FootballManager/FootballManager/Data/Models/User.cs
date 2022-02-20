using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
