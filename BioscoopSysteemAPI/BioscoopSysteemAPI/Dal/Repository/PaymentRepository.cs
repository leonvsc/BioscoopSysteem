using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class PaymentRepository
    {
        private readonly CinemaDbContext cinemaDbContext;

        public PaymentRepository(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            var payments = await cinemaDbContext.Payments.ToListAsync();
            return payments;
        }
    }
}

