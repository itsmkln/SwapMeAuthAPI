using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models.Entities;
using System.Drawing;

namespace SwapMeAngularAuthAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserInfo>().ToTable("UsersInfo");
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Offer>().ToTable("Offers");
            modelBuilder.Entity<Platform>().ToTable("Platforms");
            modelBuilder.Entity<OfferType>().ToTable("OfferTypes");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
        }
    }
}
