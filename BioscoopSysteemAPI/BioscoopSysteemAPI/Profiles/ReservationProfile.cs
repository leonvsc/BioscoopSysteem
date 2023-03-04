using AutoMapper;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.Models;

namespace BioscoopSysteemAPI.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Reservation, ReservationReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ReservationCreateDTO, Reservation>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<ReservationUpdateDTO, Reservation>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Reservation, ReservationDeleteDTO>();

        }
    }
}
