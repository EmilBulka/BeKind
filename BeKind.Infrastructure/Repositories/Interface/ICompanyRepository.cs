using BeKind.Infrastructure.Entities;
using System.Globalization;

namespace StockNewsTracker.Infrastructure.Repositories.Interface
{
    public interface ICompanyRepository : IAsyncDisposable
    {
        public Task<ICollection<CompanyDSO>> GetUserCompanies(int userId);
    }
}