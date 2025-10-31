using BeKind.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace BeKind.Infrastructure
{
    public class BeKindDataSeeder
    {
        private readonly BeKindDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public BeKindDataSeeder(BeKindDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                        foreach (var role in roles)
                        {

                            role.Name.ToUpper();
                            await _roleManager.CreateAsync(role);

                        }
                    
                }

            }
            if (await _dbContext.Database.CanConnectAsync())
            {
                string email = "admin@admin.pl";
                string password = "Admin2024!";
                if (!_dbContext.Users.Any())
                {

                    var user = new IdentityUser
                    {
                        UserName = email,
                        Email = email
                    };

                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        var roles = _dbContext.Roles.ToList();
                        await _userManager.AddToRoleAsync(user, "Admin");//temp
                        _dbContext.SaveChanges(true);
                    }

                }
            }

        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>
            {
                new IdentityRole("Admin"),
            };
        }
    }
}