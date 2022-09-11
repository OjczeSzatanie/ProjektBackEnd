﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Back_End.Data;

#nullable disable

namespace Projekt_Back_End.Migrations
{
    [DbContext(typeof(BackEndDbContext))]
    [Migration("20220911112500_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Movie_Key", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time_Of_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time_Of_Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Movie_Keys");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Screening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time_Of_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time_Of_Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Screening_Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Of_Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Screening_Rooms");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Movie_Key", b =>
                {
                    b.HasOne("Projekt_Back_End.Models.Domain.Movie", null)
                        .WithMany("Keys")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Screening", b =>
                {
                    b.HasOne("Projekt_Back_End.Models.Domain.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Back_End.Models.Domain.Screening_Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Projekt_Back_End.Models.Domain.Movie", b =>
                {
                    b.Navigation("Keys");
                });
#pragma warning restore 612, 618
        }
    }
}