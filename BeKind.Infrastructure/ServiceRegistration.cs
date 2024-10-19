using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeKind.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BeKindDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("BeKindDb")));
            services.AddScoped<BeKindDataSeeder>();
        }
    }
}
