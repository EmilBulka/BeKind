using BeKind.Infrastructure.Entities;
using Domain.Core;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public interface IMemberCompanyRepository
    {
        public Task<bool> UserCompanyExists(int companyId, int userId);
        public Task<ICollection<CompanyDSO>> GetUserCompanies(int userId);
        public Task<OperationResult> AddUserCompany(int userId, CompanyDSO company);
        public Task<OperationResult> DeleteUserCompanies(int userId, ICollection<string> companies);
    }
}