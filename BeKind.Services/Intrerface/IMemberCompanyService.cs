using BeKind.Infrastructure.Entities;
using Domain.Core;
using Domain.Entities;

namespace StockNewsTracker.Services.Intrerface
{
    public interface IMemberCompanyService
    {
        public Task<ICollection<Company>> GetUserCompanies(int userId);
        public Task<OperationResult> AddUserCompany(int userId, Company company);
        public Task<OperationResult> DeleteUserCompanies(int userId, ICollection<string> companies);
        public Task<ICollection<string>> GetAllCompaniesNames();

    }
}
