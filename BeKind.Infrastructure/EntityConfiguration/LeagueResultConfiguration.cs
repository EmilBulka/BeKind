using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class LeagueResultConfiguration : IEntityTypeConfiguration<LeagueResult>
    {
        public void Configure(EntityTypeBuilder<LeagueResult> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(lr => lr.League).WithMany(hl => hl.LeagueResults).HasForeignKey(lr => lr.LeagueId).IsRequired();
        }
    }
}
