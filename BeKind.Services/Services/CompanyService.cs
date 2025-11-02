using StockNewsTracker.Services.Intrerface;
using Domain.Entities;
using StockNewsTracker.Infrastructure.Repositories;
using StockNewsTracker.Infrastructure.Repositories.Interface;
using AutoMapper;

namespace StockNewsTracker.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Company>> GetUserCompanies(int userId)
        {
            var companiesDSO = await _companyRepository.GetUserCompanies(userId);
            var companies = _mapper.Map<ICollection<Company>>(companiesDSO);
            return companies;
        }
    }
}
