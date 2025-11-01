using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockNewsTracker.Infrastructure.EntityConfiguration
{
    public class MemberCompanyConfiguration : IEntityTypeConfiguration<MemberCompanyDSO>
    {
        private const string _tableName = "MemberCompanies";

        public void Configure(EntityTypeBuilder<MemberCompanyDSO> builder)
        {
            builder.HasKey(mc => mc.Id);
            builder.HasKey(mc => new { mc.MemberId, mc.CompanyId });

            builder.HasOne(mc => mc.Member)
                   .WithMany(m => m.MemberCompanies)
                   .HasForeignKey(mc => mc.MemberId);

            builder.HasOne(mc => mc.Company)
                   .WithMany(c => c.MemberCompanies)
                   .HasForeignKey(mc => mc.CompanyId);

            builder.ToTable(_tableName);


        }
    }
}
