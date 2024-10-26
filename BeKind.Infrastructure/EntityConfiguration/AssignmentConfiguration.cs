using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder
           .HasOne(a => a.DifficultyLevel)
           .WithMany()
           .HasForeignKey(g => g.DifficultyLevelId);

            builder.HasKey(a => a.Id);

            builder
            .ToTable("Assignments");
        }
    }
}
