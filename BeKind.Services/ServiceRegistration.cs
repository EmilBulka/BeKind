using BeKind.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeKind.Server
{
    public static class ServiceRegistration
    {
        public static void RegisterServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfrastructure(configuration);
        }
    }
}
