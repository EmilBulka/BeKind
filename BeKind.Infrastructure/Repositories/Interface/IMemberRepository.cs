using BeKind.Infrastructure.Entities;

namespace StockNewsTracker.Infrastructure.Repositories
{
    public interface IMemberRepository
    {
        Task<MemberDSO> GetMemberById(int userId, bool includeCompanies);
    }
}