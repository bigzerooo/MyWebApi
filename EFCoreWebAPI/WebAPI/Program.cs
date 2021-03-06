using DataAccessLayer.Interfaces.UnitOfWork;
using DataAccessLayer.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            IHost host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            try
            {
                IUnitOfWork unitOfWork = services.GetRequiredService<IUnitOfWork>();
                await DataInitializer.InitializeUsersWithRolesAsync(unitOfWork);
            }
            catch (Exception ex)
            {
                ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}