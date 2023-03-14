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
            modelBuilder.Entity<User>(eb =>
            {
                eb.HasMany(u => u.Offers)
                .WithOne(o => o.Seller)
                .HasForeignKey(o => o.SellerId);

                eb.HasMany(u => u.Transactions)
                .WithOne(t => t.Buyer)
                .HasForeignKey(t => t.BuyerId);

                eb.HasOne(u => u.UserInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserInfo>(ui => ui.UserId);
            });

            modelBuilder.Entity<Offer>(eb =>
            {
                eb.HasOne(o => o.OfferType)
                .WithMany(ot => ot.Offers)
                .HasForeignKey(o => o.OfferTypeId);

                eb.HasOne(o => o.Platform)
                .WithMany(p => p.Offers)
                .HasForeignKey(o => o.PlatformId);

                eb.HasOne(o => o.Game)
                .WithMany(g => g.Offers)
                .HasForeignKey(o => o.GameId);

                eb.HasOne(o => o.Transaction)
                .WithOne(t => t.Offer)
                .HasForeignKey<Transaction>(t => t.OfferId);
            });

            modelBuilder.Entity<Game>(eb =>
            {
                eb.HasOne(g => g.Image)
                .WithOne(i => i.Game)
                .HasForeignKey<Image>(i => i.GameId);

                //eb.HasOne(g => g.Genre)
                //.WithOne(ge => ge.Game)
                //.HasForeignKey<Game>(g => g.GenreId);
            });

            modelBuilder.Entity<Genre>(eb =>
            {
                eb.HasMany(ge => ge.Games)
                .WithOne(g => g.Genre)
                .HasForeignKey(g => g.GenreId);
            });


            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<UserInfo>().ToTable("UsersInfo");
            //modelBuilder.Entity<Game>().ToTable("Games");
            //modelBuilder.Entity<Image>().ToTable("Images");
            //modelBuilder.Entity<Genre>().ToTable("Genres");
            //modelBuilder.Entity<Offer>().ToTable("Offers");
            //modelBuilder.Entity<Platform>().ToTable("Platforms");
            //modelBuilder.Entity<OfferType>().ToTable("OfferTypes");
            //modelBuilder.Entity<Transaction>().ToTable("Transactions");
        }
    }
}
