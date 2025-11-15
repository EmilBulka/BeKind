using BeKind.Infrastructure.Entities;
using Domain.Core;

namespace StockNewsTracker.Infrastructure.Repositories.Interface
{
    public interface ICompanyRepository 
    {
        public Task<CompanyDSO> GetCompanyIfExists(string companyName);
        public Task<OperationResult> AddCompany(CompanyDSO company);
        public Task<ICollection<string>> GetAllCompaniesNames();
    }
}