using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Context
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameImage> GameImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<GameImage>().ToTable("GameImages");

        }
    }
}
