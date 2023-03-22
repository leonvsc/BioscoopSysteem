using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.TicketDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class TicketControllerTests
    {
        private readonly Mock<ITicketRepository> _mockTicketRepository = new Mock<ITicketRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly TicketController _ticketController;

        public TicketControllerTests()
        {
            _ticketController = new TicketController(_mockTicketRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetTickets_ReturnsOkResult_WhenTicketsExist()
        {
            // Arrange
            var domainTickets = new List<Ticket>
            {
                new Ticket { TicketId = 1, DateTime = DateTime.Now, MovieName = "ScaryMovie", PaymentId = 1, Quantity = 2, RoomId = 2, SeatId = 1, VisitorId = 2},
                new Ticket { TicketId = 2, DateTime = DateTime.Now, MovieName = "AntMan", PaymentId = 2, Quantity = 1, RoomId = 3, SeatId = 3, VisitorId = 3}
            };
            _mockTicketRepository.Setup(repo => repo.GetTicketsAsync()).ReturnsAsync(domainTickets);

            var dtoTickets = new List<TicketReadDTO>
            {
                new TicketReadDTO { TicketId = 1, DateTime = DateTime.Now, MovieName = "ScaryMovie", PaymentId = 1, Quantity = 2, RoomId = 2, SeatId = 1, VisitorId = 2},
                new TicketReadDTO { TicketId = 2, DateTime = DateTime.Now, MovieName = "AntMan", PaymentId = 2, Quantity = 1, RoomId = 3, SeatId = 3, VisitorId = 3}
            };
            _mockMapper.Setup(mapper => mapper.Map<List<TicketReadDTO>>(domainTickets)).Returns(dtoTickets);

            // Act
            var result = await _ticketController.GetTickets();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoTickets, okResult.Value);
        }

        [TestMethod]
        public async Task GetTickets_ReturnsNotFoundResult_WhenTicketsDoNotExist()
        {
            // Arrange
            _mockTicketRepository.Setup(repo => repo.GetTicketsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _ticketController.GetTickets();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetTicket_ReturnsOkResult_WhenTicketExists()
        {
            // Arrange
            var domainTicket = new Ticket { TicketId = 1, DateTime = DateTime.Now, MovieName = "ScaryMovie", PaymentId = 1, Quantity = 2, RoomId = 2, SeatId = 1, VisitorId = 2 };
            _mockTicketRepository.Setup(repo => repo.GetTicketByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainTicket);

            var dtoTicket = new TicketReadDTO { TicketId = 1, DateTime = DateTime.Now, MovieName = "ScaryMovie", PaymentId = 1, Quantity = 2, RoomId = 2, SeatId = 1, VisitorId = 2 };
            _mockMapper.Setup(mapper => mapper.Map<TicketReadDTO>(domainTicket)).Returns(dtoTicket);

            // Act
            var result = await _ticketController.GetTicket(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoTicket, okResult.Value);
        }

        [TestMethod]
        public async Task GetTicket_ReturnsBadResult_WhenTicketDoesNotExist()
        {
            // Arrange
            var domainTicket = new Ticket { TicketId = 2, DateTime = DateTime.Now, MovieName = "AntMan", PaymentId = 2, Quantity = 1, RoomId = 3, SeatId = 3, VisitorId = 3 };
            _mockTicketRepository.Setup(repo => repo.GetTicketByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainTicket);

            var dtoTicket = new TicketReadDTO { TicketId = 2, DateTime = DateTime.Now, MovieName = "AntMan", PaymentId = 2, Quantity = 1, RoomId = 3, SeatId = 3, VisitorId = 3 };
            _mockMapper.Setup(mapper => mapper.Map<TicketReadDTO>(domainTicket)).Returns(dtoTicket);

            // Act
            var result = await _ticketController.GetTicket(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PostTicket_Returns201Created_WhenValidTicketDtoIsProvided()
        {
            // Arrange
            var ticketCreateDto = new TicketCreateDTO();
            var domainTicket = new Ticket();
            var ticketId = 1;

            _mockMapper.Setup(m => m.Map<Ticket>(ticketCreateDto)).Returns(domainTicket);
            _mockTicketRepository.Setup(m => m.PostTicketAsync(domainTicket)).ReturnsAsync(new Ticket
            { TicketId = 1, DateTime = DateTime.Now, MovieName = "ScaryMovie", PaymentId = 1, Quantity = 2, RoomId = 2, SeatId = 1, VisitorId = 2 });

            var controller = new TicketController(_mockTicketRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostTicket(ticketCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetTicket", actual: createdResult.ActionName);
            Assert.AreEqual(ticketId, actual: createdResult.RouteValues["id"]);
            Assert.AreEqual(ticketCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task PostTicket_Returns204NoContent_WhenNullTicketDtoIsProvided()
        {
            // Arrange
            TicketCreateDTO? ticketCreateDto = null;

            var controller = new TicketController(_mockTicketRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostTicket(ticketCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostTicket_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var ticketCreateDto = new TicketCreateDTO();

            _mockMapper.Setup(m => m.Map<Ticket>(ticketCreateDto)).Throws(new Exception());

            var controller = new TicketController(_mockTicketRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostTicket(ticketCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
