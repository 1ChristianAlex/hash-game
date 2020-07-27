﻿// <auto-generated />
using HashGame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backend.Migrations
{
    [DbContext(typeof(DbContextGame))]
    partial class DbContextGameModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("HashGame.Models.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstPlayer")
                        .HasColumnType("TEXT");

                    b.Property<string>("guid")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HashGame.Models.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("player")
                        .HasColumnType("TEXT");

                    b.Property<int>("xPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("yPosition")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
