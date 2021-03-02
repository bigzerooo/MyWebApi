using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Configurations
{
    public static class SQLServerConfiguration
    {
        public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SQLDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("DataAccessLayer"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password = new PasswordOptions();
            }).AddEntityFrameworkStores<SQLDbContext>();

            return services;
        }
    }
}
