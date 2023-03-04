using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync();
        
        Task<ActionResult<Movie>> GetMovieByIdAsync(int id);

        Task<ActionResult<Movie>> PostMovieAsync(Movie movie);

        Task<ActionResult<Movie>> PutMovieAsync(int id, Movie movie);

        Task<ActionResult<Movie>> DeleteMovieAsync(int id);
    }
}
