namespace BeKind.Infrastructure.Entities
{
    public class HeroLeague
    {
        public int Id { get; set; }
        public List<Member> Competitors { get; set; }
        public List<LeagueResult> LeagueResults { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeagueStatus Status { get; set; }    
    }
}
