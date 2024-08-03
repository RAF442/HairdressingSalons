using AutoMapper;
using HairdressingSalons.Application.Commands.EditHairdressingSalon;
using HairdressingSalons.Application.Dto;
using HairdressingSalons.Domain.Entities;

namespace HairdressingSalons.Application.Mappings;

public class HairdressingSalonMappingProfile : Profile
{
    public HairdressingSalonMappingProfile()
    {
        CreateMap<HairdressingSalonDto, HairdressingSalon>()
            .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new HairdressingSalonContactDetails()
            {
                City = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode,
                Street = src.Street,
            }));

        CreateMap<HairdressingSalon, HairdressingSalonDto>()
            .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
            .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
            .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

        CreateMap<HairdressingSalonDto, EditHairdressingSalonCommand>();
    }
}
