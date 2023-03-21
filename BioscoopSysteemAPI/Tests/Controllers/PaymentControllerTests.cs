using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class PaymentControllerTests
    {
        private readonly Mock<IPaymentRepository> _mockPaymentRepository = new Mock<IPaymentRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly PaymentController _paymentController;

        public PaymentControllerTests()
        {
            _paymentController = new PaymentController(_mockPaymentRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetPayments_ReturnsOkResult_WhenPaymentsExist()
        {
            // Arrange
            var domainPayments = new List<Payment>
            {
                new Payment { PaymentId = 1, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 },
                new Payment { PaymentId = 2, PaymentMethod = "Payment type 2", PaidAt = DateTime.Now, Amount = 13 }
            };
            _mockPaymentRepository.Setup(repo => repo.GetPaymentsAsync()).ReturnsAsync(domainPayments);

            var dtoPayments = new List<PaymentReadDTO>
            {
                new PaymentReadDTO { PaymentId = 1, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 },
                new PaymentReadDTO { PaymentId = 2, PaymentMethod = "Payment type 2", PaidAt = DateTime.Now, Amount = 13 }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<PaymentReadDTO>>(domainPayments)).Returns(dtoPayments);

            // Act
            var result = await _paymentController.GetPayments();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoPayments, okResult.Value);
        }

        [TestMethod]
        public async Task GetPayments_ReturnsNotFoundResult_WhenPaymentsDoNotExist()
        {
            // Arrange
            _mockPaymentRepository.Setup(repo => repo.GetPaymentsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _paymentController.GetPayments();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetPayment_ReturnsOkResult_WhenPaymentExists()
        {
            // Arrange
            var domainPayment = new Payment { PaymentId = 1, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 };
            _mockPaymentRepository.Setup(repo => repo.GetPaymentByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainPayment);

            var dtoPayment = new PaymentReadDTO { PaymentId = 1, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 };
            _mockMapper.Setup(mapper => mapper.Map<PaymentReadDTO>(domainPayment)).Returns(dtoPayment);

            // Act
            var result = await _paymentController.GetPayment(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoPayment, okResult.Value);
        }

        [TestMethod]
        public async Task GetPayment_ReturnsBadResult_WhenPaymentDoesNotExist()
        {
            // Arrange
            var domainPayment = new Payment { PaymentId = 2, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 };
            _mockPaymentRepository.Setup(repo => repo.GetPaymentByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainPayment);

            var dtoPayment = new PaymentReadDTO { PaymentId = 2, PaymentMethod = "Payment type 1", PaidAt = DateTime.Now, Amount = 13 };
            _mockMapper.Setup(mapper => mapper.Map<PaymentReadDTO>(domainPayment)).Returns(dtoPayment);

            // Act
            var result = await _paymentController.GetPayment(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }
    }
}
