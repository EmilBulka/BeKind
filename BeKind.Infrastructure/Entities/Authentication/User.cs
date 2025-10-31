using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeKind.Infrastructure.Entities.Authentication
{
    public class User : IdentityUser
    {
        public IdentityRole Role { get; set; }
        public User(string userName, string role) : base(userName)
        {
            
        }
    }
}
