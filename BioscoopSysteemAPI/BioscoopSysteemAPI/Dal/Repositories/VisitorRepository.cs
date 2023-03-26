using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public VisitorRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public async Task<ActionResult<IEnumerable<Visitor>>> GetVisitorsAsync()
        {
            var visitors = await _cinemaDbContext.Visitors.ToListAsync();

            return visitors;
        }

        public async Task<ActionResult<Visitor>> GetVisitorByIdAsync(int id)
        {
            var visitor = await _cinemaDbContext.Visitors.FindAsync(id);

            return visitor;
        }

        public async Task<ActionResult<Visitor>> PostVisitorAsync(Visitor visitor)
        {
            _cinemaDbContext.Visitors.Add(visitor);
            await _cinemaDbContext.SaveChangesAsync();

            return visitor;
        }

        public async Task<ActionResult<Visitor>> DeleteVisitorAsync(int id)
        {
            var visitor = await _cinemaDbContext.Visitors.FindAsync(id);

            _cinemaDbContext.Visitors.Remove(visitor);
            await _cinemaDbContext.SaveChangesAsync();

            return visitor;
        }

        public async Task<ActionResult<Visitor>> PutVisitorAsync(int id, Visitor visitor)
        {

            var domainVisitor = await _cinemaDbContext.Visitors.FindAsync(id);

            if (domainVisitor == null)
            {
                return null;
            }

            domainVisitor.VisitorId = visitor.VisitorId;
            domainVisitor.FirstName = visitor.FirstName;
            domainVisitor.LastName = visitor.LastName;
            domainVisitor.Age = visitor.Age;
            
            await _cinemaDbContext.SaveChangesAsync();

            return domainVisitor;
        }
    }
}

