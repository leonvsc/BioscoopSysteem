using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
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

        [TestMethod]
        public async Task PostReservation_Returns201Created_WhenValidReservationDtoIsProvided()
        {
            // Arrange
            var reservationCreateDto = new ReservationCreateDTO();
            var domainReservation = new Reservation();

            _mockMapper.Setup(m => m.Map<Reservation>(reservationCreateDto)).Returns(domainReservation);
            _mockReservationRepository.Setup(m => m.PostReservationAsync(domainReservation)).ReturnsAsync(new Reservation
            { ReservationId = 1, DateTime = DateTime.Today, Location = "Amsterdam", TicketAmount = 13, Age = "16", TotalPrice = 13, IsStudent = false, WantsPopcorn = false, WantsVIP = false, WantsKinderfeestje = false});

            var controller = new ReservationController(_mockReservationRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostReservation(reservationCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetReservation", actual: createdResult.ActionName);
            Assert.AreEqual(reservationCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        /*[TestMethod]
        public async Task PostReservation_Returns201Created_WhenValidReservationDtoIsProvided()
        {
            // Arrange
            var reservationCreateDto = new ReservationCreateDTO();
            var domainReservation = new Reservation();

            _mockMapper.Setup(m => m.Map<Reservation>(reservationCreateDto)).Returns(domainReservation);
            _mockReservationRepository.Setup(m => m.PostReservationAsync(domainReservation)).ReturnsAsync(new Reservation
            { ReservationId = 21, WantsKinderfeestje = true, DateTime = DateTime.Now, TotalPrice = 13 });

            var controller = new ReservationController(_mockReservationRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostReservation(reservationCreateDto);

            // Assert
            // Aan het testen
            Assert.IsInstanceOfType(result.Result, typeof(ActionResult));
            
            var actionResult = result.Result;
            Assert.AreEqual(StatusCodes.Status201Created, actionResult);

            //Assert.AreEqual(reservationId, actual: createdResult.RouteValues["id"]);
            //Assert.AreEqual(reservationCreateDto, actual: okObjectResult.Value);
            //Assert.AreEqual(StatusCodes.Status200OK, okObjectResult.StatusCode);
        }*/

        [TestMethod]
        public async Task PostReservation_Returns204NoContent_WhenNullReservationDtoIsProvided()
        {
            // Arrange
            ReservationCreateDTO? seatCreateDto = null;

            var controller = new ReservationController(_mockReservationRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostReservation(seatCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostReservation_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var seatCreateDto = new ReservationCreateDTO();

            _mockMapper.Setup(m => m.Map<Reservation>(seatCreateDto)).Throws(new Exception());

            var controller = new ReservationController(_mockReservationRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostReservation(seatCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
