﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetRGAPI.Data;

#nullable disable

namespace PetRGAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetRGAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PetRGAPI.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PetBirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("PetBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetGuardianId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PetGuardianId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetRGAPI.Models.PetGuardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddresId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddresId")
                        .IsUnique()
                        .HasFilter("[AddresId] IS NOT NULL");

                    b.ToTable("PetGuardians");
                });

            modelBuilder.Entity("PetRGAPI.Models.Pet", b =>
                {
                    b.HasOne("PetRGAPI.Models.PetGuardian", "PetGuardian")
                        .WithMany("Pets")
                        .HasForeignKey("PetGuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetGuardian");
                });

            modelBuilder.Entity("PetRGAPI.Models.PetGuardian", b =>
                {
                    b.HasOne("PetRGAPI.Models.Address", "Address")
                        .WithOne("PetGuardian")
                        .HasForeignKey("PetRGAPI.Models.PetGuardian", "AddresId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PetRGAPI.Models.Address", b =>
                {
                    b.Navigation("PetGuardian")
                        .IsRequired();
                });

            modelBuilder.Entity("PetRGAPI.Models.PetGuardian", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}