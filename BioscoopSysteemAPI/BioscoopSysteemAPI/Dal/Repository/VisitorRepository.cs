using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class VisitorRepository
    {
        private readonly CinemaDbContext cinemaDbContext;

        public VisitorRepository(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<Visitor>> GetVisitors()
        {
            var visitors = await cinemaDbContext.Visitors.ToListAsync();
            return visitors;
        }
    }
}

