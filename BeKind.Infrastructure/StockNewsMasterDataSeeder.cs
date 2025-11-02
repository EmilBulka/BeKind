using BeKind.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeKind.Infrastructure
{
    public class StockNewsMasterDataSeeder
    {
        private readonly StockNewsMasterDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public StockNewsMasterDataSeeder(
            StockNewsMasterDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            if (!await _dbContext.Database.CanConnectAsync())
                return;

            // ---------- 1️⃣ Seed Roles ----------
            if (!await _dbContext.Roles.AnyAsync())
            {
                var roles = GetRoles();
                foreach (var role in roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }

            // ---------- 2️⃣ Seed Users ----------
            var usersList = new List<(string Email, string Password)>
    {
        ("admin1@test.com", "Password123!"),
        ("admin2@test.com", "Password123!")
    };

            foreach (var (email, password) in usersList)
            {
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser == null)
                {
                    var user = new IdentityUser { UserName = email, Email = email };
                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }

            await _dbContext.SaveChangesAsync();

            // ---------- 3️⃣ Seed Companies ----------
            var companiesToSeed = new List<CompanyDSO>
    {
        new CompanyDSO { Name = "Apple", IsNotifyActive = true },
        new CompanyDSO { Name = "Microsoft", IsNotifyActive = true },
        new CompanyDSO { Name = "Google", IsNotifyActive = true },
        new CompanyDSO { Name = "Amazon", IsNotifyActive = false },
        new CompanyDSO { Name = "Tesla", IsNotifyActive = true },
        new CompanyDSO { Name = "Netflix", IsNotifyActive = false }
    };

            foreach (var company in companiesToSeed)
            {
                bool exists = await _dbContext.Companies.AnyAsync(c => c.Name == company.Name);
                if (!exists)
                {
                    _dbContext.Companies.Add(company);
                }
            }

            await _dbContext.SaveChangesAsync();

            // ---------- 4️⃣ Seed Members and assign companies ----------
            foreach (var userEmail in usersList.Select(u => u.Email))
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                var memberExists = await _dbContext.Members.AnyAsync(m => m.UserId == user.Id);
                if (!memberExists)
                {
                    var member = new MemberDSO
                    {
                        UserId = user.Id,
                        MemberCompanies = new List<MemberCompanyDSO>()
                    };

                    var allCompanies = await _dbContext.Companies.ToListAsync();

                    // Assign all companies to this member (or pick 3 randomly if you want)
                    foreach (var company in allCompanies)
                    {
                        member.MemberCompanies.Add(new MemberCompanyDSO
                        {
                            CompanyId = company.Id,
                            IsNotifyActive = company.IsNotifyActive
                        });
                    }

                    _dbContext.Members.Add(member);
                }
            }

            await _dbContext.SaveChangesAsync();
        }


        private IEnumerable<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>
            {
                new IdentityRole("Admin")
            };
        }
    }
}
