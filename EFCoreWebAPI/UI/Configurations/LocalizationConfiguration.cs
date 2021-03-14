using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace UI.Configurations
{
    public static class LocalizationConfiguration
    {
        public static IServiceCollection AddAppLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            var supportedCultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("ru") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
                options.SupportedUICultures = supportedCultures;
            });
            return services;
        }
    }
}
