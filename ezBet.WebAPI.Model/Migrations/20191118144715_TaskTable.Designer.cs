﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ezBet.WebAPI.Model;

namespace ezBet.WebAPI.Model.Migrations
{
    [DbContext(typeof(EzBetDbContext))]
    [Migration("20191118144715_TaskTable")]
    partial class TaskTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ezBet.WebAPI.Model.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("GameId")
                        .HasColumnName("GameId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Score");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("bet");
                });

            modelBuilder.Entity("ezBet.WebAPI.Model.Entities.Game", b =>
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

            modelBuilder.Entity("ezBet.WebAPI.Model.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<byte>("Status");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("task");
                });

            modelBuilder.Entity("ezBet.WebAPI.Model.Entities.Bet", b =>
                {
                    b.HasOne("ezBet.WebAPI.Model.Entities.Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
