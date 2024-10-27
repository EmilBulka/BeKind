using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasOne(assignemnt => assignemnt.DifficultyLevel)
                   .WithMany()
                   .HasForeignKey(assignemnt => assignemnt.DifficultyLevelId);

            builder.HasMany(a => a.TargetGroups)
                   .WithMany(targetGroup => targetGroup.Assignments)
                   .UsingEntity(x => x.ToTable("AssignemntTargetGroup"));

            builder.HasKey(assignemnt => assignemnt.Id);

            builder.ToTable("Assignments");

        }
    }
}
