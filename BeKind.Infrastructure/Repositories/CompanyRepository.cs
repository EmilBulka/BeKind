using BeKind.Infrastructure;
using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using StockNewsTracker.Infrastructure.Repositories.Interface;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly StockNewsMasterDbContext _dbContext;

        public CompanyRepository(StockNewsMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        public async Task<ICollection<CompanyDSO>> GetUserCompanies(int userId)
        {
            if (_dbContext == null)
                return new List<CompanyDSO>();

            var companies = (_dbContext?.MemberCompanies != null)
                ? await _dbContext.MemberCompanies
                    .Where(mc => mc.MemberId == userId)
                    .Select(uc => new CompanyDSO
                    {
                        Id = uc.Company.Id,
                        Name = uc.Company.Name,
                        IsNotifyActive = uc.IsNotifyActive
                    })
                    .ToListAsync()
                : new List<CompanyDSO>(); 

            return companies;
        }
    }
}
