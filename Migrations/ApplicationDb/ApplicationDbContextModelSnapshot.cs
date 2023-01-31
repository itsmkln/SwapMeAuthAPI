﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwapMeAngularAuthAPI.Context;

#nullable disable

namespace SwapMeAngularAuthAPI.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int>("GameImageId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("GameImageId");

                    b.HasIndex("GenreId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.GameImage", b =>
                {
                    b.Property<int>("GameImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameImageId"));

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("GameImageId");

                    b.ToTable("Games.Image", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPhysical")
                        .HasColumnType("bit");

                    b.HasKey("OfferId");

                    b.HasIndex("GameId");

                    b.ToTable("Offers", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.OfferType", b =>
                {
                    b.Property<int>("OfferTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("OfferTypeId");

                    b.HasIndex("OfferId")
                        .IsUnique();

                    b.ToTable("Offers.Type", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("PlatformId");

                    b.HasIndex("OfferId")
                        .IsUnique();

                    b.ToTable("Platforms", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("OfferId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserInfoId"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserInfoId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users.Info", (string)null);
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Game", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.GameImage", "GameImage")
                        .WithMany()
                        .HasForeignKey("GameImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwapMeAngularAuthAPI.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameImage");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Offer", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.OfferType", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.Offer", null)
                        .WithOne("OfferType")
                        .HasForeignKey("SwapMeAngularAuthAPI.Models.OfferType", "OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Platform", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.Offer", null)
                        .WithOne("Platform")
                        .HasForeignKey("SwapMeAngularAuthAPI.Models.Platform", "OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.User", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.UserInfo", b =>
                {
                    b.HasOne("SwapMeAngularAuthAPI.Models.User", null)
                        .WithOne("UserInfo")
                        .HasForeignKey("SwapMeAngularAuthAPI.Models.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.Offer", b =>
                {
                    b.Navigation("OfferType")
                        .IsRequired();

                    b.Navigation("Platform")
                        .IsRequired();
                });

            modelBuilder.Entity("SwapMeAngularAuthAPI.Models.User", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
