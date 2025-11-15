using BeKind.Infrastructure;
using BeKind.Infrastructure.Entities;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class MemberCompanyRepository : BaseRepository, IMemberCompanyRepository
    {
        private readonly IMemberRepository _memberRepository;

        public MemberCompanyRepository(StockNewsMasterDbContext dbContext, IMemberRepository memberRepository) : base(dbContext) 
        {
            _memberRepository = memberRepository;
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

                await MasterDbContext.MemberCompanies!.AddAsync(memberCompany);
                await MasterDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Errors.Add(new Error(ex.Message));
            }

            return result;
        }

        public async Task<OperationResult> DeleteUserCompanies(int userId, ICollection<string> companies)
        {
            var result = new OperationResult();

            var member = await _memberRepository.GetMemberById(userId, true);

            if (member == null)
            {
                result.IsValid = false;
                //dopisac error
                return result;
            }

            var companiesToRemove = member.MemberCompanies
                .Where(c => companies.Contains(c.Company.Name))
                .ToList();

            foreach (var company in companiesToRemove)
            {
                member.MemberCompanies.Remove(company);
            }

            await MasterDbContext.SaveChangesAsync();

            return result;
        }
    

        public async Task<ICollection<CompanyDSO>> GetUserCompanies(int userId)
        {
            if (MasterDbContext == null)
                return new List<CompanyDSO>();

            var companies = await MasterDbContext.MemberCompanies!
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

        public async Task<bool> UserCompanyExists(int companyId, int userId)
        {
            var companyExists = await MasterDbContext.MemberCompanies!
                .AnyAsync(mc => mc.MemberId == userId && mc.CompanyId == companyId);

            return companyExists;
        }


    }
}
