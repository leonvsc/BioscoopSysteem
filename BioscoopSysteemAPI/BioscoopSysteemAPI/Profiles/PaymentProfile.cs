using AutoMapper;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            // Mapping from the domain object to the readDTO object.
            CreateMap<Payment, PaymentReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<PaymentCreateDTO, Payment>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<PaymentUpdateDTO, Payment>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Payment, PaymentDeleteDTO>();

        }
    }
}
