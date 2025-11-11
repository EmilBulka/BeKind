using BeKind.Infrastructure.Entities;
using Domain.Core;

namespace StockNewsTracker.Infrastructure.Repositories.Interface
{
    public interface ICompanyRepository : IAsyncDisposable
    {
        public Task<ICollection<CompanyDSO>> GetUserCompanies(int userId);
        public Task<OperationResult> AddUserCompany(int userId, CompanyDSO company);
        public Task<CompanyDSO> GetCompanyIfExists(string companyName);
        public Task<bool> UserCompanyExists(int companyId, int userId);
        public Task<OperationResult> AddCompany(CompanyDSO company);
        public Task<ICollection<string>> GetAllCompaniesNames();
    }
}