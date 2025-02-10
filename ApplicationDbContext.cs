using Microsoft.EntityFrameworkCore;
using VideoGameApp.Models;

namespace VideoGameApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> VideoGame { get; set; }
        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Developers
            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Developer 1", Country = "Country 1" },
                new Developer { Id = 2, Name = "Developer 2", Country = "Country 2" }
            );

            // Seed VideoGames
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Game 1", Genre = "Genre 1", Price = 29.99M, Description = "Description 1", ReleaseDate = DateTime.Now, DeveloperId = 1 },
                new VideoGame { Id = 2, Title = "Game 2", Genre = "Genre 2", Price = 39.99M, Description = "Description 2", ReleaseDate = DateTime.Now, DeveloperId = 2 }
            );
        }
    }
}
