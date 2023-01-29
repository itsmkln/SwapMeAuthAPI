using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Context
{
    public class TransactionsDbContext : DbContext
    {

        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Offer>().ToTable("Offers");
            modelBuilder.Entity<OfferType>().ToTable("OfferTypes");
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Platform>().ToTable("Platforms");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<GameImage>().ToTable("GameImages");
        }
    }
}