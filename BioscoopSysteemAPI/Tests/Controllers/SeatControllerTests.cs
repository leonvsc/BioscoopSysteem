using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.SeatDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class SeatControllerTests
    {
        private readonly Mock<ISeatRepository> _mockSeatRepository = new Mock<ISeatRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly SeatController _seatController;

        public SeatControllerTests()
        {
            _seatController = new SeatController(_mockSeatRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetSeats_ReturnsOkResult_WhenSeatsExist()
        {
            // Arrange
            var domainSeats = new List<Seat>
            {
                new Seat { SeatId = 1, MovieId = 3, SeatRow = 2, SeatNumber = 4 },
                new Seat { SeatId = 2,  MovieId = 3, SeatRow = 1, SeatNumber = 5 }
            };
            _mockSeatRepository.Setup(repo => repo.GetSeatsAsync()).ReturnsAsync(domainSeats);

            var dtoSeats = new List<SeatReadDTO>
            {
                new SeatReadDTO { SeatId = 1, MovieId = 3, SeatRow = 2, SeatNumber = 4 },
                new SeatReadDTO { SeatId = 2,  MovieId = 3, SeatRow = 1, SeatNumber = 5 }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<SeatReadDTO>>(domainSeats)).Returns(dtoSeats);

            // Act
            var result = await _seatController.GetSeats();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoSeats, okResult.Value);
        }

        [TestMethod]
        public async Task GetSeats_ReturnsNotFoundResult_WhenSeatsDoNotExist()
        {
            // Arrange
            _mockSeatRepository.Setup(repo => repo.GetSeatsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _seatController.GetSeats();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetSeat_ReturnsOkResult_WhenSeatExists()
        {
            // Arrange
            var domainSeat = new Seat { SeatId = 2, MovieId = 3, SeatRow = 1, SeatNumber = 5 };
            _mockSeatRepository.Setup(repo => repo.GetSeatByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainSeat);

            var dtoSeat = new SeatReadDTO { SeatId = 2, MovieId = 3, SeatRow = 1, SeatNumber = 5 };
            _mockMapper.Setup(mapper => mapper.Map<SeatReadDTO>(domainSeat)).Returns(dtoSeat);

            // Act
            var result = await _seatController.GetSeat(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoSeat, okResult.Value);
        }

        [TestMethod]
        public async Task GetSeat_ReturnsBadResult_WhenSeatDoesNotExist()
        {
            // Arrange
            var domainSeat = new Seat { SeatId = 1, MovieId = 3, SeatRow = 2, SeatNumber = 4 };
            _mockSeatRepository.Setup(repo => repo.GetSeatByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainSeat);

            var dtoSeat = new SeatReadDTO { SeatId = 1, MovieId = 3, SeatRow = 2, SeatNumber = 4 };
            _mockMapper.Setup(mapper => mapper.Map<SeatReadDTO>(domainSeat)).Returns(dtoSeat);

            // Act
            var result = await _seatController.GetSeat(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PostSeat_Returns201Created_WhenValidSeatDtoIsProvided()
        {
            // Arrange
            var seatCreateDto = new SeatCreateDTO();
            var domainSeat = new Seat();
            var seatId = 1;

            _mockMapper.Setup(m => m.Map<Seat>(seatCreateDto)).Returns(domainSeat);
            _mockSeatRepository.Setup(m => m.PostSeatAsync(domainSeat)).ReturnsAsync(new Seat { SeatId = 1, MovieId = 3, SeatRow = 2, SeatNumber = 4 });

            var controller = new SeatController(_mockSeatRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostSeat(seatCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetSeat", actual: createdResult.ActionName);
            Assert.AreEqual(seatId, actual: createdResult.RouteValues["id"]);
            Assert.AreEqual(seatCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task PostSeat_Returns204NoContent_WhenNullSeatDtoIsProvided()
        {
            // Arrange
            SeatCreateDTO seatCreateDto = null;

            var controller = new SeatController(_mockSeatRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostSeat(seatCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostSeat_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var seatCreateDto = new SeatCreateDTO();

            _mockMapper.Setup(m => m.Map<Seat>(seatCreateDto)).Throws(new Exception());

            var controller = new SeatController(_mockSeatRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostSeat(seatCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
