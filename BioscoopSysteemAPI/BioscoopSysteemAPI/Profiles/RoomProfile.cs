using AutoMapper;
using BioscoopSysteemAPI.DTOs.RoomDTOs;
using BioscoopSysteemAPI.Models;

namespace BioscoopSysteemAPI.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Room, RoomReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<RoomCreateDTO, Room>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<RoomUpdateDTO, Room>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Room, RoomDeleteDTO>();

        }
    }
}
