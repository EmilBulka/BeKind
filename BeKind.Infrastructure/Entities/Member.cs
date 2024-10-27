using Microsoft.AspNetCore.Identity;

namespace BeKind.Infrastructure.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public List<HeroAssignment> Assignments { get; set; }
        public HeroRank HeroRank { get; set; }  
        public int HeroRankId { get; set; }  
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
