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
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer;
using System.Reflection;
using DataAccessLayer.Helpers;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using BusinessLogicLayer.Validators;
using Microsoft.AspNetCore.Identity;

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
            //DbContext
            services.AddDbContext<MyDBContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("DataAccessLayer"));
            });

            //Identity
            services.AddIdentity<MyUser, MyRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password = new PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 6,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };                
                
            }).AddEntityFrameworkStores<MyDBContext>();

            #region repositories
            services.AddTransient<ICarStateRepository, CarStateRepository>();
            services.AddTransient<ICarTypeRepository, CarTypeRepository>();
            services.AddTransient<IClientTypeRepository, ClientTypeRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarHireRepository, CarHireRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<INewRepository, NewRepository>();
            #endregion

            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);//сборка профайла

            //SortHelpers
            services.AddTransient<ISortHelper<Car>, SortHelper<Car>>();
            services.AddTransient<ISortHelper<Client>,SortHelper<Client>>();

            #region services
            services.AddTransient<ICarStateService, CarStateService>();
            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarHireService, CarHireService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<INewService, NewService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleService, RoleService>();            
            #endregion
            
            //UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //игнорирует looping и позвол€ет доставать ассоциированые данные (дл€ eager loading)
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)                
                .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CarDTOValidator>());//добавл€ет флюент валидацию

            //#region validators            
            //services.AddTransient<IValidator<CarDTO>, CarDTOValidator>();
            //#endregion

            //JWT конфигураци€
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироватьс€ издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представл€юща€ издател€
                            ValidIssuer = Configuration["JwtIssuer"],

                            // будет ли валидироватьс€ потребитель токена
                            ValidateAudience = true,
                            // установка потребител€ токена
                            ValidAudience = Configuration["JwtAudience"],
                            // будет ли валидироватьс€ врем€ существовани€
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"])),
                            // валидаци€ ключа безопасности
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero
                        };
                    });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
