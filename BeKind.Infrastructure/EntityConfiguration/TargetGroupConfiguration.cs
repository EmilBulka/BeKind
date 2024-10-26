using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class TargetGroupConfiguration : IEntityTypeConfiguration<TargetGroup>
    {
        public void Configure(EntityTypeBuilder<TargetGroup> builder)
        {
            builder.HasData(
            Enum.GetValues(typeof(TargetGroup))
                .Cast<Entities.Enums.TargetGroup>()
                .Select(targetGroup => new TargetGroup
                {
                    Id = (int)targetGroup,
                    Description = targetGroup.ToString().InsertSpacesBetweenEach()
                }));
        }
    }
}
