using AutoMapper;
using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
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
    }
}
