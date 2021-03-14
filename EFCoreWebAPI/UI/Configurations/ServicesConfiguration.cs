using Microsoft.Extensions.DependencyInjection;
using UI.Services;

namespace UI.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<AccountService>();
            services.AddScoped<CarHiresService>();
            services.AddScoped<CarService>();
            services.AddScoped<CarStateService>();
            services.AddScoped<CarTypeService>();
            services.AddScoped<ClientService>();
            services.AddScoped<ClientTypeService>();
            services.AddScoped<LogsService>();
            services.AddScoped<NewsService>();
            return services;
        }
    }
}
