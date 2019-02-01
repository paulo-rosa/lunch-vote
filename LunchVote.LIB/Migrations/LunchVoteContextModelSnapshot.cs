﻿// <auto-generated />
using System;
using LunchVote.LIB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LunchVote.LIB.Migrations
{
    [DbContext(typeof(LunchVoteContext))]
    partial class LunchVoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LunchVote.LIB.Entities.Professional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Professionals");
                });

            modelBuilder.Entity("LunchVote.LIB.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("LunchVote.LIB.Entities.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProfessionalId");

                    b.Property<Guid>("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("LunchVote.LIB.Entities.Vote", b =>
                {
                    b.HasOne("LunchVote.LIB.Entities.Professional", "Professional")
                        .WithMany()
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LunchVote.LIB.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
