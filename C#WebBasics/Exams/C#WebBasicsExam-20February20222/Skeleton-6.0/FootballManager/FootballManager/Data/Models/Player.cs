using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get;set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
