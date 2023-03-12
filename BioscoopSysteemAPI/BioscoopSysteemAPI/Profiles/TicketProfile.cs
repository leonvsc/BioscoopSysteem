using AutoMapper;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.DTOs.TicketDTOs;
using BioscoopSysteemAPI.DTOs.VisitorDTOs;
using BioscoopSysteemAPI.Models;

namespace BioscoopSysteemAPI.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Ticket, TicketReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<TicketCreateDTO, Ticket>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<TicketUpdateDTO, Ticket>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Ticket, TicketDeleteDTO>();

        }
    }
}
