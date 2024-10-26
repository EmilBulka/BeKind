using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class AssignmentStatusConfiguration : IEntityTypeConfiguration<Entities.AssignmentStatus>
    {
        public void Configure(EntityTypeBuilder<Entities.AssignmentStatus> builder)
        {
            builder.HasData(
            Enum.GetValues(typeof(Entities.AssignmentStatus))
                .Cast<Entities.Enums.AssignmentStatus>()
                .Select(status => new DifficultyLevel
                {
                    Id = (int)status,
                    Description = status.ToString().InsertSpacesBetweenEach()
                }));
        }
    }
}
