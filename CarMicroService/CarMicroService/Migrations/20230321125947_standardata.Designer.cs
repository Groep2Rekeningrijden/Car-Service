﻿// <auto-generated />
using CarMicroService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarMicroService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230321125947_standardata")]
    partial class standardata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarMicroService.Model.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarTypeId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarTypeId = 1,
                            Description = "benzine auto volvo v90",
                            Name = "volvo V90"
                        });
                });

            modelBuilder.Entity("CarMicroService.Model.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("PricePerKilometer")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("carTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Benzine auto",
                            Name = "Benzine",
                            PricePerKilometer = 0.11
                        });
                });

            modelBuilder.Entity("CarMicroService.Model.CarModel", b =>
                {
                    b.HasOne("CarMicroService.Model.CarType", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarType");
                });
#pragma warning restore 612, 618
        }
    }
}
