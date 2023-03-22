using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.VisitorDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class VisitorControllerTests
    {
        private readonly Mock<IVisitorRepository> _mockVisitorRepository = new Mock<IVisitorRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly VisitorController _visitorController;

        public VisitorControllerTests()
        {
            _visitorController = new VisitorController(_mockVisitorRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetVisitors_ReturnsOkResult_WhenVisitorsExist()
        {
            // Arrange
            var domainVisitors = new List<Visitor>
            {
                new Visitor { VisitorId = 1, Age = 12, FirstName = "Freek", LastName = "Rodriguez"},
                new Visitor { VisitorId = 2, Age = 21, FirstName = "Renuka", LastName = "Verhage"}
            };
            _mockVisitorRepository.Setup(repo => repo.GetVisitorsAsync()).ReturnsAsync(domainVisitors);

            var dtoVisitors = new List<VisitorReadDTO>
            {
                new VisitorReadDTO { VisitorId = 1, Age = 12, FirstName = "Freek", LastName = "Rodriguez"},
                new VisitorReadDTO { VisitorId = 2, Age = 21, FirstName = "Renuka", LastName = "Verhage"}
            };
            _mockMapper.Setup(mapper => mapper.Map<List<VisitorReadDTO>>(domainVisitors)).Returns(dtoVisitors);

            // Act
            var result = await _visitorController.GetVisitors();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoVisitors, okResult.Value);
        }

        [TestMethod]
        public async Task GetVisitors_ReturnsNotFoundResult_WhenVisitorsDoNotExist()
        {
            // Arrange
            _mockVisitorRepository.Setup(repo => repo.GetVisitorsAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _visitorController.GetVisitors();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetVisitor_ReturnsOkResult_WhenVisitorExists()
        {
            // Arrange
            var domainVisitor = new Visitor { VisitorId = 1, Age = 12, FirstName = "Freek", LastName = "Rodriguez" };
            _mockVisitorRepository.Setup(repo => repo.GetVisitorByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainVisitor);

            var dtoVisitor = new VisitorReadDTO { VisitorId = 1, Age = 12, FirstName = "Freek", LastName = "Rodriguez" };
            _mockMapper.Setup(mapper => mapper.Map<VisitorReadDTO>(domainVisitor)).Returns(dtoVisitor);

            // Act
            var result = await _visitorController.GetVisitor(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoVisitor, okResult.Value);
        }

        [TestMethod]
        public async Task GetVisitor_ReturnsBadResult_WhenVisitorDoesNotExist()
        {
            // Arrange
            var domainVisitor = new Visitor { VisitorId = 2, Age = 21, FirstName = "Renuka", LastName = "Verhage" };
            _mockVisitorRepository.Setup(repo => repo.GetVisitorByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainVisitor);

            var dtoVisitor = new VisitorReadDTO { VisitorId = 2, Age = 21, FirstName = "Renuka", LastName = "Verhage" };
            _mockMapper.Setup(mapper => mapper.Map<VisitorReadDTO>(domainVisitor)).Returns(dtoVisitor);

            // Act
            var result = await _visitorController.GetVisitor(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PostVisitor_Returns201Created_WhenValidVisitorDtoIsProvided()
        {
            // Arrange
            var visitorCreateDto = new VisitorCreateDTO();
            var domainVisitor = new Visitor();
            var visitorId = 1;

            _mockMapper.Setup(m => m.Map<Visitor>(visitorCreateDto)).Returns(domainVisitor);
            _mockVisitorRepository.Setup(m => m.PostVisitorAsync(domainVisitor)).ReturnsAsync(new Visitor
            { VisitorId = 2, Age = 21, FirstName = "Renuka", LastName = "Verhage" });

            var controller = new VisitorController(_mockVisitorRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostVisitor(visitorCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetVisitor", actual: createdResult.ActionName);
            Assert.AreEqual(visitorId, actual: createdResult.RouteValues["id"]);
            Assert.AreEqual(visitorCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task PostVisitor_Returns204NoContent_WhenNullVisitorDtoIsProvided()
        {
            // Arrange
            VisitorCreateDTO? visitorCreateDto = null;

            var controller = new VisitorController(_mockVisitorRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostVisitor(visitorCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostVisitor_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var visitorCreateDto = new VisitorCreateDTO();

            _mockMapper.Setup(m => m.Map<Visitor>(visitorCreateDto)).Throws(new Exception());

            var controller = new VisitorController(_mockVisitorRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostVisitor(visitorCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
