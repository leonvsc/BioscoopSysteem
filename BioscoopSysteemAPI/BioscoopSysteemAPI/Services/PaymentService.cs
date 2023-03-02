using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Dal.Repository;
using System;

public class PaymentService
{
	private readonly PaymentRepository paymentRepository;
	public PaymentService(PaymentRepository paymentRepository)
	{
		this.paymentRepository = paymentRepository;
	}

	private async Task <IEnumerable<Payment>> GetPayments()
    {
		var payments = await this.paymentRepository.GetPayments();
		return payments;
	}

	private async Task <Payment> GetPaymentById(int id)
    {
		var payment = await this.paymentRepository.GetPaymentById(id);
		return payment;
    }
}
