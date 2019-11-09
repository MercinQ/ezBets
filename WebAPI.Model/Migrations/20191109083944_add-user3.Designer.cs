﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.Model;

namespace WebAPI.Model.Migrations
{
    [DbContext(typeof(EzBetDbContext))]
    [Migration("20191109083944_add-user3")]
    partial class adduser3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebAPI.Model.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("GameId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Score");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("bet");
                });

            modelBuilder.Entity("WebAPI.Model.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("BetEndDate");

                    b.Property<DateTime>("BetStartDate");

                    b.Property<string>("GameState")
                        .HasMaxLength(16);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("game");
                });

            modelBuilder.Entity("WebAPI.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Hash");

                    b.Property<string>("Password");

                    b.Property<string>("Username")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("WebAPI.Model.Entities.Bet", b =>
                {
                    b.HasOne("WebAPI.Model.Entities.Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
