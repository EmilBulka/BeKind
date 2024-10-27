using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class HeroAssignmentConfiguration : IEntityTypeConfiguration<HeroAssignment>
    {
        public void Configure(EntityTypeBuilder<HeroAssignment> builder)
        {
            builder
          .Property(ha => ha.StartTime);
            builder
           .Property(ha => ha.CompletedTime);
            builder
           .Property(ha => ha.EndTime);
            builder
            .ToTable("HeroAssignments");

            builder
           .HasOne(a => a.AssignmentStatus)
           .WithMany()
           .HasForeignKey(ha => ha.AssignmentId);
        }
    }
}
