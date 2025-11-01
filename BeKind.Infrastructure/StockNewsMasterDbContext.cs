using BeKind.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockNewsTracker.Infrastructure.EntityConfiguration;

namespace BeKind.Infrastructure
{
    public class StockNewsMasterDbContext : IdentityDbContext
    {
        public DbSet<CompanyDSO>? Companies{ get; set; }
        public DbSet<MemberDSO>? Members{ get; set; }
        public DbSet<MemberCompanyDSO>? MemberCompanies{ get; set; }


        public StockNewsMasterDbContext(DbContextOptions<StockNewsMasterDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new MemberConfiguration().Configure(builder.Entity<MemberDSO>());
            new CompanyConfiguration().Configure(builder.Entity<CompanyDSO>());
            new MemberCompanyConfiguration().Configure(builder.Entity<MemberCompanyDSO>());

            base.OnModelCreating(builder);
        }

    }
}
