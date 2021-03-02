using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Interfaces.UnitOfWork;
using DataAccessLayer.Repositories.MongoDBRepositories;
using DataAccessLayer.Repositories.SQLRepositories;
using DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICarStateRepository, SQLCarStateRepository>();
            services.AddTransient<ICarTypeRepository, SQLCarTypeRepository>();
            services.AddTransient<IClientTypeRepository, SQLClientTypeRepository>();
            services.AddTransient<ICarRepository, SQLCarRepository>();
            services.AddTransient<ICarHireRepository, SQLCarHireRepository>();
            services.AddTransient<IClientRepository, SQLClientRepository>();
            services.AddTransient<INewsRepository, MongoNewsRepository>();
            services.AddTransient<ILogsRepository, MongoLogsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
