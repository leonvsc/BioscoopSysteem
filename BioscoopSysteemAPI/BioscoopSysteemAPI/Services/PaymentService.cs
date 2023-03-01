// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using BioscoopSysteemAPI.Models;
// using BioscoopSysteemAPI.Repository;
// using System;
//
// public class PaymentService
// {
// 	private readonly PaymentRepository paymentRepository;
// 	public PaymentService(PaymentRepository paymentRepository)
// 	{
// 		this.paymentRepository = paymentRepository;
// 	}
//
// 	private IsEnumerable<Payment> GetPayments()
//     {
// 		var payments = this.paymentRepository.GetPayments();
// 		return payments;
// 	}
//
// 	private Payment GetPayment()
//     {
// 		var payment = this.paymentRepository.GetPayment();
// 		return payment;
//     }
// }
