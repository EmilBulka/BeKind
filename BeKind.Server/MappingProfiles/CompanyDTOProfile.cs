using AutoMapper;
using Domain.Entities;
using StockNewsTracker.Server.Dto;

public class CompanyDTOProfile : Profile
{
    public CompanyDTOProfile()
    {
        CreateMap<CompanyDTO, Company>()

            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IsNotifyActive, opt => opt.MapFrom(src => src.IsNotifyActive));

        CreateMap<Company, CompanyDTO>()

            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IsNotifyActive, opt => opt.MapFrom(src => src.IsNotifyActive));
    }
}
