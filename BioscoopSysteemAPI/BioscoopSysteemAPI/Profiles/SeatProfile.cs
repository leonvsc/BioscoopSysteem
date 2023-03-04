using AutoMapper;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.DTOs.SeatDTOs;
using BioscoopSysteemAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Profiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Seat, SeatReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<SeatCreateDTO, Seat>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<SeatUpdateDTO, Seat>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Seat, SeatDeleteDTO>();

        }
    }
}
