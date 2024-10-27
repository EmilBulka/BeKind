using BeKind.Infrastructure.Entities;
using BeKind.Infrastructure.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeKind.Infrastructure
{
    public class BeKindDbContext : IdentityDbContext
    {
        public DbSet<Member>? Members{ get; set; }
        public DbSet<Assignment>? Assignments{ get; set; }
        public DbSet<HeroAssignment>? HeroAssignments{ get; set; }
        public DbSet<HeroLeague>? HeroLeagues{ get; set; }
        public DbSet<LeagueResult>? LeagueResults{ get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<AssignmentStatus> AssignmentStatus { get; set; }
        public DbSet<Entities.HeroRank> HeroRank { get; set; }
        public DbSet<LeagueStatus> LeagueStatus { get; set; }
        public DbSet<TargetGroup> TargetGroup { get; set; }

        public BeKindDbContext(DbContextOptions<BeKindDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new AssignmentConfiguration().Configure(builder.Entity<Assignment>());
            new HeroAssignmentConfiguration().Configure(builder.Entity<HeroAssignment>());
            new DifficultyLevelConfiguration().Configure(builder.Entity<DifficultyLevel>());
            new MemberConfiguration().Configure(builder.Entity<Member>());
            new LeagueResultConfiguration().Configure(builder.Entity<LeagueResult>());
            new HeroLeagueConfiguration().Configure(builder.Entity<HeroLeague>());
            new AssignmentStatusConfiguration().Configure(builder.Entity<AssignmentStatus>());
            new HeroRankConfiguration().Configure(builder.Entity<Entities.HeroRank>());
            new LeagueStatusConfiguration().Configure(builder.Entity<LeagueStatus>());
            new TargetGroupConfiguration().Configure(builder.Entity<TargetGroup>());

            base.OnModelCreating(builder);
        }

    }
}
