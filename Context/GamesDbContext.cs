﻿using Microsoft.EntityFrameworkCore;
using SwapMeAngularAuthAPI.Models;

namespace SwapMeAngularAuthAPI.Context
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Platform>().ToTable("Platforms");
            modelBuilder.Entity<GameImage>().ToTable("GameImages");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Offer>().ToTable("Offers");

        }
    }
}
