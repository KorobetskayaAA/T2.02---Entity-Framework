﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MurrrcatConsoleCodeFirst.DAL;

namespace MurrrcatConsoleCodeFirst.Migrations
{
    [DbContext(typeof(MurrcatContext))]
    [Migration("20211123130455_InitialCreateConventions")]
    partial class InitialCreateConventions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CatCategory", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("CatsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoriesId", "CatsId");

                    b.HasIndex("CatsId");

                    b.ToTable("CatCategory");
                });

            modelBuilder.Entity("MurrrcatConsoleCodeFirst.DAL.Cat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("CutenessSum")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VotesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("MurrrcatConsoleCodeFirst.DAL.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MurrrcatConsoleCodeFirst.DAL.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("CatCategory", b =>
                {
                    b.HasOne("MurrrcatConsoleCodeFirst.DAL.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MurrrcatConsoleCodeFirst.DAL.Cat", null)
                        .WithMany()
                        .HasForeignKey("CatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MurrrcatConsoleCodeFirst.DAL.Cat", b =>
                {
                    b.HasOne("MurrrcatConsoleCodeFirst.DAL.Owner", "Owner")
                        .WithMany("Cats")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MurrrcatConsoleCodeFirst.DAL.Owner", b =>
                {
                    b.Navigation("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}
