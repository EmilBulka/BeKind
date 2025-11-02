using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockNewsTracker.Infrastructure.EntityConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyDSO>
    {
        public void Configure(EntityTypeBuilder<CompanyDSO> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.IsNotifyActive);
        }
    }
}
