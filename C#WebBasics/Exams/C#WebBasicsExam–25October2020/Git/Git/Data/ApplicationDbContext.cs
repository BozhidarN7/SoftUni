using Git.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Git.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Commit> Commits { get; set; }

        public DbSet<Repository> Repositories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-7SFRFQN\SQLEXPRESS;Database=Git;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Commit>(entity =>
            {
                entity.HasOne(c => c.Repository)
                .WithMany(r => r.Commits)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Creator)
                .WithMany(u => u.Commits)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
