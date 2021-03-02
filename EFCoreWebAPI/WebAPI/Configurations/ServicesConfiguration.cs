using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICarStateService, CarStateService>();
            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarHireService, CarHireService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ILogsService, LogsService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleService, RoleService>();
            return services;
        }
    }
}
