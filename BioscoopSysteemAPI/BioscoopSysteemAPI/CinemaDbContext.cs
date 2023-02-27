using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BioscoopSysteemAPI
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 1,
                Name = "ScaryMovie",
                Description = "Lorem ipsum dolor sit amet",
                Price = 12,
                AllowedAge = 16,
                ImageUrl = "/Images/Movies/Movie1.jpeg",
                RoomId = 5
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 2,
                Name = "AntMan",
                Description = "Lorem ipsum dolor sit amet",
                Price = 9,
                AllowedAge = 8,
                ImageUrl = "/Images/Movies/Movie2.jpeg",
                RoomId = 4
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 3,
                Name = "Plane",
                Description = "Lorem ipsum dolor sit amet",
                Price = 12,
                AllowedAge = 12,
                ImageUrl = "/Images/Movies/Movie3.jpeg",
                RoomId = 3
            });

            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                PaymentId = 1,
                DateTime = DateTime.Now,
                Amount = 24,
                PaymentMethod = "Ideal",
                ReservationId = 1
            });

            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                PaymentId = 2,
                DateTime = DateTime.Now,
                Amount = 12,
                PaymentMethod = "CreditCard",
                ReservationId = 2
            });

            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                PaymentId = 3,
                DateTime = DateTime.Now,
                Amount = 12,
                PaymentMethod = "CreditCard",
                ReservationId = 3
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationId = 1,
                DateTime = DateTime.Now,
                Location = "Amsterdam",
                SeatId = 6,
                MovieId = 1,
                VisitorId = 1
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationId = 2,
                DateTime = DateTime.Now,
                Location = "Haarlem",
                SeatId = 5,
                MovieId = 2,
                VisitorId = 2
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationId = 3,
                DateTime = DateTime.Now,
                Location = "Zaandam",
                SeatId = 4,
                MovieId = 3,
                VisitorId = 3
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 1,
                InUse = false,
                NumberOfSeatsAvailable = 150
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 2,
                InUse = false,
                NumberOfSeatsAvailable = 250
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 3,
                InUse = false,
                NumberOfSeatsAvailable = 75
            });


            modelBuilder.Entity<Seat>().HasData(new Seat
            {
                SeatId = 1,
                SeatNumber = 8,
                SeatRow = 3,
                MovieId = 1
            });

            modelBuilder.Entity<Seat>().HasData(new Seat
            {
                SeatId = 2,
                SeatNumber = 14,
                SeatRow = 2,
                MovieId = 2
            });

            modelBuilder.Entity<Seat>().HasData(new Seat
            {
                SeatId = 3,
                SeatNumber = 16,
                SeatRow = 1,
                MovieId = 3
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 1,
                DateTime = DateTime.Now,
                MovieName = "ScaryMovie",
                Quantity = 2,
                SeatId = 1,
                VisitorId = 2,
                RoomId = 2,
                PaymentId = 1
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 2,
                DateTime = DateTime.Now,
                MovieName = "AntMan",
                Quantity = 1,
                SeatId = 3,
                VisitorId = 3,
                RoomId = 3,
                PaymentId = 2
            });

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 3,
                DateTime = DateTime.Now,
                MovieName = "Plane",
                Quantity = 1,
                SeatId = 2,
                VisitorId = 1,
                RoomId = 1,
                PaymentId = 3
            });

            modelBuilder.Entity<Visitor>().HasData(new Visitor
            {
                VisitorId = 1,
                FirstName = "Piet",
                LastName = "Avans",
                Age = 25
            });

            modelBuilder.Entity<Visitor>().HasData(new Visitor
            {
                VisitorId = 2,
                FirstName = "Jan",
                LastName = "School",
                Age = 28
            });

            modelBuilder.Entity<Visitor>().HasData(new Visitor
            {
                VisitorId = 3,
                FirstName = "Hans",
                LastName = "Koning",
                Age = 19
            });

        }



        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Visitor> Visitors => Set<Visitor>();
    }
}

