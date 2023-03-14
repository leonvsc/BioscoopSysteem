using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BioscoopSysteemAPI
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Visitor> Visitors => Set<Visitor>();
        public DbSet<MovieRoom> MovieRoom { get; set; }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Making the relation with the foreign keys
            modelBuilder.Entity<MovieRoom>().HasKey(mgg => new { mgg.MovieId, mgg.RoomId });

            modelBuilder.Entity<Movie>().HasData(SeedHelper.GetMovieSeeds());

            modelBuilder.Entity<Payment>().HasData(SeedHelper.GetPaymentSeeds());
            
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("float");

            modelBuilder.Entity<Reservation>().HasData(SeedHelper.GetReservationSeeds());

            modelBuilder.Entity<Room>().HasData(SeedHelper.GetRoomSeeds());

            modelBuilder.Entity<Seat>().HasData(SeedHelper.GetSeatSeeds());

            modelBuilder.Entity<Ticket>().HasData(SeedHelper.GetTicketSeeds());

            modelBuilder.Entity<Visitor>().HasData(SeedHelper.GetVisitorSeeds());

            modelBuilder.Entity<MovieRoom>().HasData(SeedHelper.GetMovieRoomSeeds());

        }

    }
}