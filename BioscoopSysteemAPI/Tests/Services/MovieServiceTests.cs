using System.Collections.Generic;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BioscoopSysteemAPI.Test.Services
{
    [TestClass]
    public class MovieServiceTest
    {
        [TestMethod]
        public void GetFilteredMovie_ReturnsFilteredMovies_WhenFiltersAreApplied()
        {
            // Arrange
            var movieService = new MovieService();
            var filterDTO = new FilterDTO
            {
                genre = Genre.Avonturen.ToString(),
                search = "Terminator",
                age = 18,
                subtitles = true,
                threeDee = true,
                specials = Specials.HorrorNight.ToString(),
                language = "English"
            };
            var movies = new List<Movie>
            {
                new Movie
                {
                    Name = "Terminator 2: Judgment Day",
                    Genre = Genre.Avonturen.ToString(),
                    AllowedAge = 18,
                    Subtitles = true,
                    Add3DMovie = true,
                    Specials = Specials.HorrorNight.ToString(),
                    Language = "English"
                },
                new Movie
                {
                    Name = "The Shawshank Redemption",
                    Genre = Genre.Actie.ToString(),
                    AllowedAge = 16,
                    Subtitles = false,
                    Add3DMovie = false,
                    Specials = Specials.Marathon.ToString(),
                    Language = "English"
                }
            };

            // Act
            var result = movieService.GetFilteredMovie(filterDTO, movies);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Terminator 2: Judgment Day", result[0].Name);
        }
    }
}