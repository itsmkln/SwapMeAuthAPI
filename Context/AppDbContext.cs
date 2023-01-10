using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Dtos;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //    .HasOne(a => a.UserInfo)
            //    .WithOne(b => b.User);
        //        .HasForeignKey<UserInfo>(e => e.User);


            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserInfo>().ToTable("Users.Info");
        }
    }
}
