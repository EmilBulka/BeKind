using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class HeroRankConfiguration : IEntityTypeConfiguration<HeroRank>
    {
        public void Configure(EntityTypeBuilder<HeroRank> builder)
        {
            builder.HasData(
            Enum.GetValues(typeof(Entities.Enums.HeroRank))
                .Cast<Entities.Enums.HeroRank>()
                .Select(heroRank => new HeroRank
                {
                    Id = (int)heroRank,
                    Description = heroRank.ToString().InsertSpacesBetweenEach()
                }));
        }
    }
}
