using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class ReservationControllerTests
    {
        private readonly Mock<IReservationRepository> _mockReservationRepository = new Mock<IReservationRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly ReservationController _reservationController;

        public ReservationControllerTests()
        {
            _reservationController = new ReservationController(_mockReservationRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetReservations_ReturnsOkResult_WhenReservationsExist()
        {
            // Arrange
            var domainReservations = new List<Reservation>
            {
                new Reservation { ReservationId = 1, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 },
                new Reservation { ReservationId = 2, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 }
            };
            _mockReservationRepository.Setup(repo => repo.GetReservationsAsync()).ReturnsAsync(domainReservations);

            var dtoReservations = new List<ReservationReadDTO>
            {
                new ReservationReadDTO { ReservationId = 1, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 },
                new ReservationReadDTO { ReservationId = 2, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<ReservationReadDTO>>(domainReservations)).Returns(dtoReservations);

            // Act
            var result = await _reservationController.GetReservations();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoReservations, okResult.Value);
        }

        [TestMethod]
        public async Task GetReservations_ReturnsNotFoundResult_WhenReservationsDoNotExist()
        {
            // Arrange
            _mockReservationRepository.Setup(repo => repo.GetReservationsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _reservationController.GetReservations();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetReservation_ReturnsOkResult_WhenReservationExists()
        {
            // Arrange
            var domainReservation = new Reservation { ReservationId = 1, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 };
            _mockReservationRepository.Setup(repo => repo.GetReservationByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainReservation);

            var dtoReservation = new ReservationReadDTO { ReservationId = 1, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 };
            _mockMapper.Setup(mapper => mapper.Map<ReservationReadDTO>(domainReservation)).Returns(dtoReservation);

            // Act
            var result = await _reservationController.GetReservation(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoReservation, okResult.Value);
        }

        [TestMethod]
        public async Task GetReservation_ReturnsBadResult_WhenReservationDoesNotExist()
        {
            // Arrange
            var domainReservation = new Reservation { ReservationId = 2, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 };
            _mockReservationRepository.Setup(repo => repo.GetReservationByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainReservation);

            var dtoReservation = new ReservationReadDTO { ReservationId = 2, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 };
            _mockMapper.Setup(mapper => mapper.Map<ReservationReadDTO>(domainReservation)).Returns(dtoReservation);

            // Act
            var result = await _reservationController.GetReservation(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }
    }
}
