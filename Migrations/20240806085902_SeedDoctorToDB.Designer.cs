﻿// <auto-generated />
using System;
using Happy_Health.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Happy_Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240806085902_SeedDoctorToDB")]
    partial class SeedDoctorToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Happy_Health.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            Name = "Dr. Smith",
                            PhoneNumber = "09043892210",
                            Specialty = "Cardiology"
                        },
                        new
                        {
                            DoctorId = 2,
                            Name = "Dr. Jones",
                            PhoneNumber = "08026589420",
                            Specialty = "Neurology"
                        });
                });

            modelBuilder.Entity("Happy_Health.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2007, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Wasiu Ademola"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1999, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Charles John"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(2009, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Shola Fakuade"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
