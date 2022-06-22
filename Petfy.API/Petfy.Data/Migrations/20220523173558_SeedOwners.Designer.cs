﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petfy.Data;

#nullable disable

namespace Petfy.Data.Migrations
{
    [DbContext(typeof(PetfyDbContext))]
    [Migration("20220523173558_SeedOwners")]
    partial class SeedOwners
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Petfy.Data.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Address 123",
                            DateOfBirth = new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default"
                        });
                });

            modelBuilder.Entity("Petfy.Data.Models.Pet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<int?>("PetNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Petfy.Data.Models.PetVaccine", b =>
                {
                    b.Property<int>("PetID")
                        .HasColumnType("int");

                    b.Property<int>("VaccineID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2");

                    b.HasKey("PetID", "VaccineID");

                    b.HasIndex("VaccineID");

                    b.ToTable("PetVaccine");
                });

            modelBuilder.Entity("Petfy.Data.Models.Vaccine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Lab")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vaccines");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Lab = "Lab Demo",
                            Name = "Vaccine Demo"
                        });
                });

            modelBuilder.Entity("Petfy.Data.Models.Pet", b =>
                {
                    b.HasOne("Petfy.Data.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Petfy.Data.Models.PetVaccine", b =>
                {
                    b.HasOne("Petfy.Data.Models.Pet", "Pet")
                        .WithMany("PetVaccines")
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Petfy.Data.Models.Vaccine", "Vaccine")
                        .WithMany("PetVaccines")
                        .HasForeignKey("VaccineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("Petfy.Data.Models.Owner", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Petfy.Data.Models.Pet", b =>
                {
                    b.Navigation("PetVaccines");
                });

            modelBuilder.Entity("Petfy.Data.Models.Vaccine", b =>
                {
                    b.Navigation("PetVaccines");
                });
#pragma warning restore 612, 618
        }
    }
}