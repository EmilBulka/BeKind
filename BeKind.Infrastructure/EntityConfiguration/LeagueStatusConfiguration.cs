using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class LeagueStatusConfiguration : IEntityTypeConfiguration<LeagueStatus>
    {
        public void Configure(EntityTypeBuilder<LeagueStatus> builder)
        {
            builder.HasData(
            Enum.GetValues(typeof(LeagueStatus))
                .Cast<Entities.Enums.LeagueStatus>()
                .Select(status => new LeagueStatus
                {
                    Id = (int)status,
                    Description = status.ToString().InsertSpacesBetweenEach()
                }));
        }
    }
}
