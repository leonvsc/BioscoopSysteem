using AutoMapper;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.DTOs.VisitorDTOs;
using BioscoopSysteemAPI.Models;

namespace BioscoopSysteemAPI.Profiles
{
    public class VisitorProfile : Profile
    {
        public VisitorProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Visitor, VisitorReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<VisitorCreateDTO, Visitor>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<VisitorUpdateDTO, Visitor>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Visitor, VisitorDeleteDTO>();

        }
    }
}
