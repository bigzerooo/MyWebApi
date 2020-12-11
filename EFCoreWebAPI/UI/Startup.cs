using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.JWT;
using UI.Services;
using UI.Validators;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();            

            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddBlazoredLocalStorage();
            //services.AddAuthorizationCore();            
            //services.AddScoped<IAuthService, AuthService>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            var supportedCultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("ru") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedUICultures = supportedCultures;
            });

            services.AddHttpClient<CarService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<AccountService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<CarTypeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<CarStateService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<ClientTypeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<ClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<NewsService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddHttpClient<CarHiresService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44337");
            });
            services.AddSingleton<HttpClient>();

            services.AddValidatorsFromAssemblyContaining<CarViewModelValidator>();

            




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
