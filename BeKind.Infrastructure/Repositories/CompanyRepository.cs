using BeKind.Infrastructure;
using BeKind.Infrastructure.Entities;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using StockNewsTracker.Infrastructure.Repositories.Interface;
using System.Numerics;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly StockNewsMasterDbContext _dbContext;

        public CompanyRepository(StockNewsMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> AddUserCompany(int userId, CompanyDSO company)
        {
            var result = new OperationResult(true);

            try
            {
                var memberCompany = new MemberCompanyDSO
                {
                    MemberId = userId,
                    CompanyId = company.Id,
                    IsNotifyActive = company.IsNotifyActive 
                };

                await _dbContext.MemberCompanies!.AddAsync(memberCompany);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Errors.Add(new Error(ex.Message));
            }

            return result;
        }

        public async Task<ICollection<CompanyDSO>> GetUserCompanies(int userId)
        {
            if (_dbContext == null)
                return new List<CompanyDSO>();

            var companies = await _dbContext.MemberCompanies!
                    .Where(mc => mc.MemberId == userId)
                    .Select(uc => new CompanyDSO
                    {
                        Id = uc.Company.Id,
                        Name = uc.Company.Name,
                        IsNotifyActive = uc.IsNotifyActive
                    })
                    .ToListAsync();

            return companies;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> UserCompanyExists(int companyId, int userId)
        {
            var companyExists = await _dbContext.MemberCompanies!
                .AnyAsync(mc => mc.MemberId == userId && mc.CompanyId == companyId);

            return companyExists;
        }

        public async Task<CompanyDSO> GetCompanyIfExists(string companyName)
        {
            var company = await _dbContext.Companies!
                .Where(mc => mc.Name.Replace(" ", "").ToLower().Equals(companyName.Replace(" ", "").ToLower()))
                .FirstOrDefaultAsync();

            return company!;
        }

        public async Task<OperationResult> AddCompany(CompanyDSO company)
        {
            var result = new OperationResult(true);
            try
            {
                await _dbContext.Companies!.AddAsync(company);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Errors.Add(new Error(ex.Message));
            }

            return result;
        }

        public async Task<ICollection<string>> GetAllCompaniesNames()
        {
            return await _dbContext.Companies!.Select(x => x.Name).ToListAsync();
        }
    }
}
