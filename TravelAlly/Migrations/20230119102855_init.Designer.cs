﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAlly.Data;

#nullable disable

namespace TravelAlly.Migrations
{
    [DbContext(typeof(TravelAllyContext))]
    [Migration("20230119102855_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelAlly.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Continent = "Europe",
                            Country = "United Kingdom",
                            Lat = 51.507221999999999,
                            Lon = -0.1275,
                            Name = "London"
                        },
                        new
                        {
                            Id = 2,
                            Continent = "Europe",
                            Country = "France",
                            Lat = 48.864716000000001,
                            Lon = 2.3490139999999999,
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 3,
                            Continent = "Europe",
                            Country = "United Kingdom",
                            Lat = 51.316366000000002,
                            Lon = -0.55783300000000002,
                            Name = "Woking"
                        },
                        new
                        {
                            Id = 4,
                            Continent = "Europe",
                            Country = "United Kingdom",
                            Lat = 51.26332,
                            Lon = -1.090735,
                            Name = "Basingstoke"
                        });
                });

            modelBuilder.Entity("TravelAlly.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AcceptsTypes")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lon")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Station");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcceptsTypes = 1,
                            CityId = 1,
                            Lat = 51.530000000000001,
                            Lon = -0.125278,
                            Name = "St. Pancras International"
                        },
                        new
                        {
                            Id = 2,
                            AcceptsTypes = 1,
                            CityId = 2,
                            Lat = 48.881110999999997,
                            Lon = 2.3552780000000002,
                            Name = "Gare du Nord"
                        },
                        new
                        {
                            Id = 5,
                            AcceptsTypes = 1,
                            CityId = 4,
                            Lat = 51.268419999999999,
                            Lon = -1.08857,
                            Name = "Basingstoke Railway Station"
                        },
                        new
                        {
                            Id = 4,
                            AcceptsTypes = 1,
                            CityId = 3,
                            Lat = 51.319029999999998,
                            Lon = -0.55598000000000003,
                            Name = "Woking Railway Station"
                        },
                        new
                        {
                            Id = 3,
                            AcceptsTypes = 1,
                            CityId = 1,
                            Lat = 51.503100000000003,
                            Lon = -0.1132,
                            Name = "London Waterloo"
                        });
                });

            modelBuilder.Entity("TravelAlly.Models.StationPassing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.HasIndex("TransportId");

                    b.ToTable("StationPassing");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartureTime = new DateTime(2023, 1, 19, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            StationId = 5,
                            TransportId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2023, 1, 19, 9, 8, 0, 0, DateTimeKind.Unspecified),
                            DepartureTime = new DateTime(2023, 1, 19, 9, 9, 0, 0, DateTimeKind.Unspecified),
                            StationId = 4,
                            TransportId = 1
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2023, 1, 19, 9, 41, 0, 0, DateTimeKind.Unspecified),
                            StationId = 3,
                            TransportId = 1
                        });
                });

            modelBuilder.Entity("TravelAlly.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OperatesOnDays")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transport");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Carrier = "South Western Railway",
                            OperatesOnDays = 21,
                            Type = 1
                        });
                });

            modelBuilder.Entity("TravelAlly.Models.Station", b =>
                {
                    b.HasOne("TravelAlly.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TravelAlly.Models.StationPassing", b =>
                {
                    b.HasOne("TravelAlly.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAlly.Models.Transport", "Transport")
                        .WithMany("StationPassings")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("TravelAlly.Models.Transport", b =>
                {
                    b.Navigation("StationPassings");
                });
#pragma warning restore 612, 618
        }
    }
}