using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeKind.Infrastructure.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public List<Assignment> Assignments { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
