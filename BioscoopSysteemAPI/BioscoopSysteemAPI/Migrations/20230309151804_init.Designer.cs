﻿// <auto-generated />
using System;
using BioscoopSysteemAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20230309151804_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<bool>("Add3DMovie")
                        .HasColumnType("bit");

                    b.Property<byte>("AllowedAge")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Add3DMovie = true,
                            AllowedAge = (byte)16,
                            Date = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2502),
                            Description = "Lorem ipsum dolor sit amet",
                            ImageUrl = "/Images/Movies/Movie1.jpeg",
                            Name = "ScaryMovie",
                            Price = 12
                        },
                        new
                        {
                            MovieId = 2,
                            Add3DMovie = false,
                            AllowedAge = (byte)8,
                            Date = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2543),
                            Description = "Lorem ipsum dolor sit amet",
                            ImageUrl = "/Images/Movies/Movie2.jpeg",
                            Name = "AntMan",
                            Price = 9
                        },
                        new
                        {
                            MovieId = 3,
                            Add3DMovie = true,
                            AllowedAge = (byte)12,
                            Date = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2546),
                            Description = "Lorem ipsum dolor sit amet",
                            ImageUrl = "/Images/Movies/Movie3.jpeg",
                            Name = "Plane",
                            Price = 12
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.MovieRoom", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("MovieRoom");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            RoomId = 2
                        },
                        new
                        {
                            MovieId = 2,
                            RoomId = 3
                        },
                        new
                        {
                            MovieId = 3,
                            RoomId = 1
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            Amount = 24,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2619),
                            PaymentMethod = "Ideal",
                            ReservationId = 1
                        },
                        new
                        {
                            PaymentId = 2,
                            Amount = 12,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2624),
                            PaymentMethod = "CreditCard",
                            ReservationId = 2
                        },
                        new
                        {
                            PaymentId = 3,
                            Amount = 12,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2626),
                            PaymentMethod = "CreditCard",
                            ReservationId = 3
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2670),
                            Location = "Amsterdam",
                            MovieId = 1,
                            SeatId = 6,
                            VisitorId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2675),
                            Location = "Haarlem",
                            MovieId = 2,
                            SeatId = 5,
                            VisitorId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2677),
                            Location = "Zaandam",
                            MovieId = 3,
                            SeatId = 4,
                            VisitorId = 3
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<bool>("InUse")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfSeatsAvailable")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            InUse = false,
                            NumberOfSeatsAvailable = 150
                        },
                        new
                        {
                            RoomId = 2,
                            InUse = false,
                            NumberOfSeatsAvailable = 250
                        },
                        new
                        {
                            RoomId = 3,
                            InUse = false,
                            NumberOfSeatsAvailable = 75
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatRow")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            SeatId = 1,
                            MovieId = 1,
                            SeatNumber = 8,
                            SeatRow = 3
                        },
                        new
                        {
                            SeatId = 2,
                            MovieId = 2,
                            SeatNumber = 14,
                            SeatRow = 2
                        },
                        new
                        {
                            SeatId = 3,
                            MovieId = 3,
                            SeatNumber = 16,
                            SeatRow = 1
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2725),
                            MovieName = "ScaryMovie",
                            PaymentId = 1,
                            Quantity = 2,
                            RoomId = 2,
                            SeatId = 1,
                            VisitorId = 2
                        },
                        new
                        {
                            TicketId = 2,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2729),
                            MovieName = "AntMan",
                            PaymentId = 2,
                            Quantity = 1,
                            RoomId = 3,
                            SeatId = 3,
                            VisitorId = 3
                        },
                        new
                        {
                            TicketId = 3,
                            DateTime = new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2732),
                            MovieName = "Plane",
                            PaymentId = 3,
                            Quantity = 1,
                            RoomId = 1,
                            SeatId = 2,
                            VisitorId = 1
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitorId"));

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            VisitorId = 1,
                            Age = (byte)25,
                            FirstName = "Piet",
                            LastName = "Avans"
                        },
                        new
                        {
                            VisitorId = 2,
                            Age = (byte)28,
                            FirstName = "Jan",
                            LastName = "School"
                        },
                        new
                        {
                            VisitorId = 3,
                            Age = (byte)19,
                            FirstName = "Hans",
                            LastName = "Koning"
                        });
                });

            modelBuilder.Entity("BioscoopSysteemAPI.Models.MovieRoom", b =>
                {
                    b.HasOne("BioscoopSysteemAPI.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioscoopSysteemAPI.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
