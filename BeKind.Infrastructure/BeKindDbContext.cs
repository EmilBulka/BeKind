using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.Entities.Authentication;
using BeKind.Infrastructure.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeKind.Infrastructure
{
    public class BeKindDbContext : IdentityDbContext
    {
        public DbSet<Member>? Members{ get; set; }


        public BeKindDbContext(DbContextOptions<BeKindDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new MemberConfiguration().Configure(builder.Entity<Member>());

            base.OnModelCreating(builder);
        }

    }
}
