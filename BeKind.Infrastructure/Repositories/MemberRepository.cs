using BeKind.Infrastructure;
using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {

        public MemberRepository(StockNewsMasterDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<MemberDSO> GetMemberById(int userId, bool includeCompanies)
        {
            var memberQuery = MasterDbContext.Members.AsQueryable();

            if (includeCompanies)
            {
                memberQuery = memberQuery
                    .Include(u => u.MemberCompanies)
                    .ThenInclude(mc => mc.Company);   
            }
               return await memberQuery.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
