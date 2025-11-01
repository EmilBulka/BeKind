using StockNewsTracker.Services.Intrerface;
using Domain.Entities;
using StockNewsTracker.Infrastructure.Repositories;

namespace StockNewsTracker.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICollection<Company>> GetUserCompanies(int userId)
        {
            var companiesDSO = await _companyRepository.GetUserCompanies(userId);
            return new List<Company>();
        }
    }
}
