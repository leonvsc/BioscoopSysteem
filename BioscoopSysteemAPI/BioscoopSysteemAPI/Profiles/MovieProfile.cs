using AutoMapper;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Movie, MovieReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<MovieCreateDTO, Movie>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<MovieUpdateDTO, Movie>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Movie, MovieDeleteDTO>();

        }
    }
}
