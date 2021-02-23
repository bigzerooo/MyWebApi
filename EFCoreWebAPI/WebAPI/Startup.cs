using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Validators;
using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Repositories.MongoDBRepositories;
using DataAccessLayer.Repositories.SQLRepositories;
using DataAccessLayer.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Text;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SQLDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("DataAccessLayer"));
            });

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
            }).AddEntityFrameworkStores<SQLDbContext>();

            #region MongoDb
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            #endregion

            #region repositories
            services.AddTransient<ICarStateRepository, CarStateRepository>();
            services.AddTransient<ICarTypeRepository, CarTypeRepository>();
            services.AddTransient<IClientTypeRepository, ClientTypeRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarHireRepository, CarHireRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<INewRepository, MongoNewRepository>();
            services.AddTransient<ILogsRepository, MongoLogsRepository>();
            #endregion

            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);
            services.AddTransient<ISortHelper<Car>, SortHelper<Car>>();
            services.AddTransient<ISortHelper<Client>, SortHelper<Client>>();

            #region services
            services.AddTransient<ICarStateService, CarStateService>();
            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarHireService, CarHireService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<INewService, NewService>();
            services.AddTransient<ILogsService, LogsService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRoleService, RoleService>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CarDTOValidator>());//добавляет флюент валидацию

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = Configuration["JwtIssuer"],
                            ValidateAudience = true,
                            ValidAudience = Configuration["JwtAudience"],
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"])),
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero
                        };
                    });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });
        }

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}