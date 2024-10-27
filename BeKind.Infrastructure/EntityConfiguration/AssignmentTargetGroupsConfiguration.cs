using BeKind.Infrastructure.Entities.ManyToManyRelationObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class AssignmentTargetGroupsConfiguration : IEntityTypeConfiguration<AssignmentTargetGroups>
    {
        public void Configure(EntityTypeBuilder<AssignmentTargetGroups> builder)
        {
            builder.HasKey(atg => new { atg.TargetGroupId, atg.AssignmentId});
        }
    }
}
