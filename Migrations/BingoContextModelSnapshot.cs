﻿// <auto-generated />
using System;
using Bingo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bingo.Migrations
{
    [DbContext(typeof(BingoContext))]
    partial class BingoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Bingo.Models.BingoCard", b =>
                {
                    b.Property<int>("CardNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CardNumber");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Bingo.Models.BingoGame", b =>
                {
                    b.Property<int>("GameNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("GameNumber");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Bingo.Models.BingoGameNumber", b =>
                {
                    b.Property<int>("GameNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DrawTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("GameNumber", "Number");

                    b.ToTable("GameNumbers");
                });

            modelBuilder.Entity("Bingo.Models.BingoNumber", b =>
                {
                    b.Property<int>("CardNumber")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("CardNumber", "Number");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("Bingo.Models.BingoGameNumber", b =>
                {
                    b.HasOne("Bingo.Models.BingoGame", "Game")
                        .WithMany("Numbers")
                        .HasForeignKey("GameNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bingo.Models.BingoNumber", b =>
                {
                    b.HasOne("Bingo.Models.BingoCard", "Card")
                        .WithMany("Numbers")
                        .HasForeignKey("CardNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
