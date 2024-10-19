using BeKind.Infrastructure.Entities;
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
            base.OnModelCreating(builder);
            builder.Entity<Member>().HasKey(e => e.Id); 
        }
    }
}
