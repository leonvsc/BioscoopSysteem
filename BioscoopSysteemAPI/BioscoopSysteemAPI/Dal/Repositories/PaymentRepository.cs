﻿using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public PaymentRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsAsync()
        {
            var payments = await _cinemaDbContext.Payments.ToListAsync();
            
            return payments;
        }

        public async Task<ActionResult<Payment>> GetPaymentByIdAsync(int id)
        {
            var payment = await _cinemaDbContext.Payments.FindAsync(id);
            
            return payment;
        }

        public async Task<ActionResult<Payment>> PostPaymentAsync(Payment payment)
        {
            _cinemaDbContext.Payments.Add(payment);
            await _cinemaDbContext.SaveChangesAsync();

            return payment;
        }

        public async Task<ActionResult<Payment>> DeletePaymentAsync(int id)
        {
            var payment = await _cinemaDbContext.Payments.FindAsync(id);

            _cinemaDbContext.Payments.Remove(payment);
            await _cinemaDbContext.SaveChangesAsync();

            return payment;
        }

        public async Task<ActionResult<Payment>> PutPaymentAsync(int id, Payment payment)
        {

            var domainPayment = _cinemaDbContext.Payments.Find(id);

            await _cinemaDbContext.SaveChangesAsync();

            return domainPayment;
        }
    }
}

