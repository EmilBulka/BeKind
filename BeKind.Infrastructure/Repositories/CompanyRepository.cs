using BeKind.Infrastructure;
using BeKind.Infrastructure.Entities;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using StockNewsTracker.Infrastructure.Repositories.Interface;
using System.Numerics;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(StockNewsMasterDbContext dbContext) : base(dbContext) 
        {

        }
        public async Task<CompanyDSO> GetCompanyIfExists(string companyName)
        {
            var company = await MasterDbContext.Companies!
                .Where(mc => mc.Name.Replace(" ", "").ToLower().Equals(companyName.Replace(" ", "").ToLower()))
                .FirstOrDefaultAsync();

            return company!;
        }

        public async Task<OperationResult> AddCompany(CompanyDSO company)
        {
            var result = new OperationResult(true);
            try
            {
                await MasterDbContext.Companies!.AddAsync(company);
                await MasterDbContext.SaveChangesAsync();
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
            return await MasterDbContext.Companies!.Select(x => x.Name).ToListAsync();
        }
    }
}
