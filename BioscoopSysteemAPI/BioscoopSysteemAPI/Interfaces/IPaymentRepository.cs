using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface IPaymentRepository
    {
        Task<ActionResult<IEnumerable<Payment>>> GetPaymentsAsync();

        Task<ActionResult<Payment>> GetPaymentByIdAsync(int id);

        Task<ActionResult<Payment>> PostPaymentAsync(Payment payment);
        Task<ActionResult<Payment>> PutPaymentAsync(int id, Payment payment);

        Task<ActionResult<Payment>> DeletePaymentAsync(int id);
    }
}
