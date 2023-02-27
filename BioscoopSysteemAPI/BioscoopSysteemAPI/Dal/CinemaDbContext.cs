using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Dal
{
    public class CinemaDbContext : DbContext
    {
        // Properties for creating the tables in the SSMS with the EF.

        // Table of Movie
        public DbSet<Movie> Movie { get; set; }

        // Table of Payment
        public DbSet<Payment> Payment { get; set; }

        // Table of Reservation
        public DbSet<Reservation> Reservation { get; set; }

        // Table of Room
        public DbSet<Room> Room { get; set; }

        // Table of Seat
        public DbSet<Seat> Seat { get; set; }

        // Table of Ticket
        public DbSet<Ticket> Ticket { get; set; }

        // Table of Ticket
        public DbSet<Visitor> Visitor { get; set; }

        /// <summary>
        /// Constructor for the use of the connection string in the Program.cs
        /// </summary>
        /// <param name="options"></param>
        public CinemaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeded data for movies.
            //modelBuilder.Entity<Movie>().HasData(SeedHelper.GetCompanySeeds());

          

        }

    }
}
