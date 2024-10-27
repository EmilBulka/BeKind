using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    internal class HeroLeagueConfiguration : IEntityTypeConfiguration<HeroLeague>
    {
        public void Configure(EntityTypeBuilder<HeroLeague> builder)
        {
            builder.HasMany(hl => hl.LeagueResults).WithOne(lr => lr.League).HasForeignKey(lr => lr.LeagueId).IsRequired();
            builder.HasOne(hl => hl.Status).WithMany().HasForeignKey(hl => hl.StatusId);
        }
    }
}
