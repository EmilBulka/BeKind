using BeKind.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeKind.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(m => m.User)
                .WithOne().HasForeignKey<Member>(m => m.UserId)
                .IsRequired();


            builder.HasMany(m => m.Assignments).WithOne(a => a.Member);
            builder.HasOne(m => m.HeroRank).WithMany().HasForeignKey(hr => hr.HeroRankId);
        }
    }
}
