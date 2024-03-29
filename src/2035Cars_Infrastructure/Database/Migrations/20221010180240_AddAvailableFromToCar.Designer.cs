﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2035Cars_Infrastructure.Database;

#nullable disable

namespace _2035Cars_Infrastructure.Database.Migrations
{
    [DbContext(typeof(CarDbContext))]
    [Migration("20221010180240_AddAvailableFromToCar")]
    partial class AddAvailableFromToCar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_2035Cars_Core.Domain.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AmountOfDoor")
                        .HasColumnType("int");

                    b.Property<int>("AmountOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriveType")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("PriceForOneHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RentalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RentedTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLoggedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<long>("RentalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("AcceptEmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CostOfRental")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<long>("FromRentalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PublishEmployeeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ToRentalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.RefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Rental", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Car", b =>
                {
                    b.HasOne("_2035Cars_Core.Domain.Rental", "Rental")
                        .WithMany("Cars")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("_2035Cars_Core.ValueObjects.CarEquipment", "Equipment", b1 =>
                        {
                            b1.Property<long>("CarId")
                                .HasColumnType("bigint");

                            b1.Property<bool>("HasAirCooling")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasAutomaticGearBox")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasBuildInNavigation")
                                .HasColumnType("bit");

                            b1.Property<bool>("HasHeatingSeat")
                                .HasColumnType("bit");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.Navigation("Equipment")
                        .IsRequired();

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Client", b =>
                {
                    b.OwnsOne("_2035Cars_Core.ValueObjects.Person", "Person", b1 =>
                        {
                            b1.Property<long>("ClientId")
                                .HasColumnType("bigint");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(35)
                                .HasColumnType("nvarchar(35)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Employee", b =>
                {
                    b.HasOne("_2035Cars_Core.Domain.Rental", "Rental")
                        .WithMany("Employees")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("_2035Cars_Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("EmployeeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("_2035Cars_Core.ValueObjects.Person", "Person", b1 =>
                        {
                            b1.Property<long>("EmployeeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(35)
                                .HasColumnType("nvarchar(35)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("_2035Cars_Core.ValueObjects.Account", "Account", b1 =>
                        {
                            b1.Property<long>("EmployeeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasMaxLength(35)
                                .HasColumnType("nvarchar(35)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Person")
                        .IsRequired();

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Rental", b =>
                {
                    b.OwnsOne("_2035Cars_Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("RentalId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("nvarchar(70)");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rentals");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("_2035Cars_Core.Domain.Rental", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
