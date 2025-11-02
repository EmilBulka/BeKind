using AutoMapper;
using BeKind.Infrastructure.Entities;
using Domain.Entities;

namespace StockNewsTracker.Services.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyDSO, Company>()
                .ForMember(dest => dest.RecordId, opt => opt.MapFrom(company => company.Id))
                .ForMember(dest => dest.IsNotifyActive, opt => opt.MapFrom(company => company.IsNotifyActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(company => company.Name));

            CreateMap<Company, CompanyDSO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(company => company.RecordId))
                .ForMember(dest => dest.IsNotifyActive, opt => opt.MapFrom(company => company.IsNotifyActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(company => company.Name));
        }
    }
}
