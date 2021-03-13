using BusinessLogicLayer.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using WebAPI.Configurations;
using Newtonsoft.Json.Serialization;

namespace WebAPI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSQLServer(configuration);
            services.AddMongoDb(configuration);
            services.AddRedis(configuration);
            services.AddRepositories();
            services.AddHelpers();
            services.AddServices();
            services.AddMvc()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CarDTOValidator>())
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddJWTAuthentication(configuration);
            services.AddControllers();
            services.AddSwagger();
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
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1"));
        }
    }
}