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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Repositories.SpecificRepositories;
using DataAccessLayer.Interfaces;
using DataAccessLayer.UnitOfWork;
using Newtonsoft.Json;
using DataAccessLayer.Entities.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTO;

namespace WebAPI
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
            //Identity
            
            services.AddIdentity<MyUser, MyRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MyDBContext>();

            services.AddDbContext<MyDBContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("DataAccessLayer"));
            });            

           

            #region repositories
            services.AddTransient<ICarStateRepository, CarStateRepository>();
            services.AddTransient<ICarTypeRepository, CarTypeRepository>();
            services.AddTransient<IClientTypeRepository, ClientTypeRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarHireRepository, CarHireRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            #endregion

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<CarHire, CarHireDTO>();
                cfg.CreateMap<CarType, CarTypeDTO>();
                cfg.CreateMap<CarState, CarStateDTO>();
                cfg.CreateMap<Car, CarDTO>();
                cfg.CreateMap<Client, ClientDTO>();
                cfg.CreateMap<ClientType, ClientTypeDTO>();

                cfg.CreateMap<CarHireDTO, CarHire>();
                cfg.CreateMap<CarTypeDTO, CarType>();
                cfg.CreateMap<CarStateDTO, CarState>();
                cfg.CreateMap<CarDTO, Car>();
                cfg.CreateMap<ClientDTO, Client>();
                cfg.CreateMap<ClientTypeDTO, ClientType>();
            },typeof(Startup));//Startup?
            #region services
            services.AddTransient<ICarStateService, CarStateService>();
            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarHireService, CarHireService>();
            services.AddTransient<IClientService, ClientService>();
            #endregion
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers();


            //игнорирует looping и позволяет доставать ассоциированые данные
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
