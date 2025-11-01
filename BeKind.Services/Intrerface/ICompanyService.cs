using Domain.Entities;

namespace StockNewsTracker.Services.Intrerface
{
    public interface ICompanyService
    {
        public Task<ICollection<Company>> GetUserCompanies(int userId);
    }
}
