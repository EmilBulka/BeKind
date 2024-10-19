using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeKind.Infrastructure.Entities
{
    public class Member
    {
        public int Id { get; set; }
        IdentityUser UserInfo { get; set; }
    }
}
