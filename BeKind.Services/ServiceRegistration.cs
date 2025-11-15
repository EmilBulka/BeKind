using BeKind.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockNewsTracker.Services.Factory;
using StockNewsTracker.Services.Intrerface;
using StockNewsTracker.Services.Intrerface.Factory;
using StockNewsTracker.Services.MappingProfiles;
using StockNewsTracker.Services.Services;

namespace BeKind.Server
{
    public static class ServiceRegistration
    {
        public static void RegisterServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfrastructure(configuration);

            services.AddScoped<IMemberCompanyService, MemberCompanyService>();

            var apiKey = configuration.GetValue<string>("OpenAI:ApiKey");

            services.AddSingleton<IChatServiceFactory>(new ChatServiceFactory(apiKey));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
            });
        }
    }
}
