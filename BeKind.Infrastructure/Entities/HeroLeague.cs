using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeKind.Infrastructure.Entities.Enums;

namespace BeKind.Infrastructure.Entities
{
    public class HeroLeague
    {
        public int Id { get; set; }
        public List<Member> Competitors { get; set; }
        public List<LeagueResult> LeagueResults { get; set; }
        public LeagueStatus Status { get; set; }    
    }
}
