namespace BeKind.Infrastructure.Entities
{
    public class LeagueResult
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member MemberInfo { get; set; }
        public int HeroPoints { get; set; }
        public int Position { get; set; } 
        public int LeagueId { get; set; }
        public HeroLeague League { get; set; }
    }
}