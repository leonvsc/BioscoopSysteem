using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.RoomDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class RoomControllerTests
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository = new Mock<IRoomRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly RoomController _roomController;

        public RoomControllerTests()
        {
            _roomController = new RoomController(_mockRoomRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetRooms_ReturnsOkResult_WhenRoomsExist()
        {
            // Arrange
            var domainRooms = new List<Room>
            {
                new Room { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50},
                new Room { RoomId = 2,  InUse = true, NumberOfSeatsAvailable = 30}
            };
            _mockRoomRepository.Setup(repo => repo.GetRoomsAsync()).ReturnsAsync(domainRooms);

            var dtoRooms = new List<RoomReadDTO>
            {
                new RoomReadDTO { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50},
                new RoomReadDTO { RoomId = 2,  InUse = true, NumberOfSeatsAvailable = 30}
            };
            _mockMapper.Setup(mapper => mapper.Map<List<RoomReadDTO>>(domainRooms)).Returns(dtoRooms);

            // Act
            var result = await _roomController.GetRooms();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoRooms, okResult.Value);
        }

        [TestMethod]
        public async Task GetRooms_ReturnsNotFoundResult_WhenRoomsDoNotExist()
        {
            // Arrange
            _mockRoomRepository.Setup(repo => repo.GetRoomsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _roomController.GetRooms();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetRoom_ReturnsOkResult_WhenRoomExists()
        {
            // Arrange
            var domainRoom = new Room { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50 };
            _mockRoomRepository.Setup(repo => repo.GetRoomByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainRoom);

            var dtoRoom = new RoomReadDTO { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50 };
            _mockMapper.Setup(mapper => mapper.Map<RoomReadDTO>(domainRoom)).Returns(dtoRoom);

            // Act
            var result = await _roomController.GetRoom(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoRoom, okResult.Value);
        }

        [TestMethod]
        public async Task GetRoom_ReturnsBadResult_WhenRoomDoesNotExist()
        {
            // Arrange
            var domainRoom = new Room { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50 };
            _mockRoomRepository.Setup(repo => repo.GetRoomByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainRoom);

            var dtoRoom = new RoomReadDTO { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50 };
            _mockMapper.Setup(mapper => mapper.Map<RoomReadDTO>(domainRoom)).Returns(dtoRoom);

            // Act
            var result = await _roomController.GetRoom(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PostRoom_Returns201Created_WhenValidRoomDtoIsProvided()
        {
            // Arrange
            var roomCreateDto = new RoomCreateDTO();
            var domainRoom = new Room();
            var roomId = 1;

            _mockMapper.Setup(m => m.Map<Room>(roomCreateDto)).Returns(domainRoom);
            _mockRoomRepository.Setup(m => m.PostRoomAsync(domainRoom)).ReturnsAsync(new Room
            { RoomId = 1, InUse = true, NumberOfSeatsAvailable = 50 });

            var controller = new RoomController(_mockRoomRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostRoom(roomCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetRoom", actual: createdResult.ActionName);
            Assert.AreEqual(roomId, actual: createdResult.RouteValues["id"]);
            Assert.AreEqual(roomCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task PostRoom_Returns204NoContent_WhenNullRoomDtoIsProvided()
        {
            // Arrange
            RoomCreateDTO? roomCreateDto = null;

            var controller = new RoomController(_mockRoomRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostRoom(roomCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostRoom_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var roomCreateDto = new RoomCreateDTO();

            _mockMapper.Setup(m => m.Map<Room>(roomCreateDto)).Throws(new Exception());

            var controller = new RoomController(_mockRoomRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostRoom(roomCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
