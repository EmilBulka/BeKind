using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Entities.Enums;
using BeKind.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure
{
    public class DifficultyLevelConfiguration : IEntityTypeConfiguration<DifficultyLevel>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevel> builder)
        {
            builder.HasData(
            Enum.GetValues(typeof(Difficulty))
                .Cast<Difficulty>()
                .Select(difficulty => new DifficultyLevel
                {
                    Id = (int)difficulty + 1,
                    Description = difficulty.ToString().InsertSpacesBetweenEach()
                }));

        }
    }
}