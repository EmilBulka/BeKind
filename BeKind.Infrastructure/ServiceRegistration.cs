using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockNewsTracker.Infrastructure.Repositories;
using StockNewsTracker.Infrastructure.Repositories.Interface;

namespace BeKind.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StockNewsMasterDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("BulczoConnectionStringDev_MasterDb")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<StockNewsMasterDbContext>();

            services.AddScoped<UserManager<IdentityUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddScoped<StockNewsMasterDataSeeder>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
