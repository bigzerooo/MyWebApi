using AutoMapper;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebAPI.Configurations
{
    public static class HelpersConfiguration
    {
        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);
            services.AddTransient<ISortHelper<Car>, SortHelper<Car>>();
            services.AddTransient<ISortHelper<Client>, SortHelper<Client>>();
            services.AddTransient<IMongoHelper, MongoHelper>();
            return services;
        }
    }
}
