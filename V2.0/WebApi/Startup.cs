using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Interfaces.IServices;
using DataAccessLayer.Repositories.SQL_Repositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Services;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.UnitOfWork;
namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddControllers();
            #region SQL repositories
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarHireRepository, CarHireRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            #endregion

            #region SQL services
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarHireService, CarHireService>();
            services.AddTransient<IClientService, ClientService>();            
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
