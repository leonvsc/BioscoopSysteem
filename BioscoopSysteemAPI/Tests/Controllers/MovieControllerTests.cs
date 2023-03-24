using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class MovieControllerTests
    {
        private readonly Mock<IMovieRepository> _mockMovieRepository = new Mock<IMovieRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly MovieController _movieController;

        public MovieControllerTests()
        {
            _movieController = new MovieController(_mockMovieRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetMovies_ReturnsOkResult_WhenMoviesExist()
        {
            // Arrange
            var domainMovies = new List<Movie>
            {
                new Movie { MovieId = 1, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" },
                new Movie { MovieId = 2, Name = "Movie 2", Date = DateTime.Now, Description = "Description 2" }
            };
            _mockMovieRepository.Setup(repo => repo.GetMoviesAsync()).ReturnsAsync(domainMovies);

            var dtoMovies = new List<MovieReadDTO>
            {
                new MovieReadDTO { MovieId = 1, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" },
                new MovieReadDTO { MovieId = 2, Name = "Movie 2", Date = DateTime.Now, Description = "Description 2" }
            };
            _mockMapper.Setup(mapper => mapper.Map<List<MovieReadDTO>>(domainMovies)).Returns(dtoMovies);

            // Act
            var result = await _movieController.GetMovies();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoMovies, okResult.Value);
        }

        [TestMethod]
        public async Task GetMovies_ReturnsNotFoundResult_WhenMoviesDoNotExist()
        {
            // Arrange
            _mockMovieRepository.Setup(repo => repo.GetMoviesAsync()).ReturnsAsync(() => null);

            // Act
            var result = await _movieController.GetMovies();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetMovie_ReturnsOkResult_WhenMovieExists()
        {
            // Arrange
            var domainMovie = new Movie { MovieId = 1, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" };
            _mockMovieRepository.Setup(repo => repo.GetMovieByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainMovie);

            var dtoMovie = new MovieReadDTO { MovieId = 1, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" };
            _mockMapper.Setup(mapper => mapper.Map<MovieReadDTO>(domainMovie)).Returns(dtoMovie);

            // Act
            var result = await _movieController.GetMovie(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(dtoMovie, okResult.Value);
        }

        [TestMethod]
        public async Task GetMovie_ReturnsBadResult_WhenMovieDoesNotExist()
        {
            // Arrange
            var domainMovie = new Movie { MovieId = 2, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" };
            _mockMovieRepository.Setup(repo => repo.GetMovieByIdAsync(It.IsAny<int>())).ReturnsAsync(() => domainMovie);

            var dtoMovie = new MovieReadDTO { MovieId = 2, Name = "Movie 1", Date = DateTime.Now, Description = "Description 1" };
            _mockMapper.Setup(mapper => mapper.Map<MovieReadDTO>(domainMovie)).Returns(dtoMovie);

            // Act
            var result = await _movieController.GetMovie(1);

            // Assert
            Assert.IsNotInstanceOfType(result.Result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PostMovie_Returns201Created_WhenValidMovieDtoIsProvided()
        {
            // Arrange
            var movieCreateDto = new MovieCreateDTO();
            var domainMovie = new Movie();

            _mockMapper.Setup(m => m.Map<Movie>(movieCreateDto)).Returns(domainMovie);
            _mockMovieRepository.Setup(m => m.PostMovieAsync(domainMovie)).ReturnsAsync(new Movie
            { Name = "ScaryMovie", 
                Date = DateTime.Today, 
                Add3DMovie = false, 
                Description = "The return of unit testing", 
                Price = 12, 
                AllowedAge = 16, 
                ImageUrl = "/Images/Movies/Movie1.jpeg", 
                Genre = "Horror", 
                Language = "English", 
                Specials = "Ladies Night", 
                Subtitles = true
            });

            var controller = new MovieController(_mockMovieRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostMovie(movieCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual("GetMovie", actual: createdResult.ActionName);
            Assert.AreEqual(movieCreateDto, actual: createdResult.Value);
            Assert.AreEqual(StatusCodes.Status201Created, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task PostMovie_Returns204NoContent_WhenNullMovieDtoIsProvided()
        {
            // Arrange
            MovieCreateDTO? movieCreateDto = null;

            var controller = new MovieController(_mockMovieRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostMovie(movieCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NoContentResult));
            var noContentResult = result.Result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, actual: noContentResult.StatusCode);
        }

        [TestMethod]
        public async Task PostMovie_Returns500InternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var movieCreateDto = new MovieCreateDTO();

            _mockMapper.Setup(m => m.Map<Movie>(movieCreateDto)).Throws(new Exception());

            var controller = new MovieController(_mockMovieRepository.Object, _mockMapper.Object);

            // Act
            var result = await controller.PostMovie(movieCreateDto);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
            var objectResult = result.Result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, actual: objectResult.StatusCode);
            Assert.AreEqual("Error retrieving data from the database", objectResult.Value);
        }
    }
}
