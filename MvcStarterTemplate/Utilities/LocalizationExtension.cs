using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;

namespace MvcStarterTemplate.Utilities
{
    public static class LocalizationExtension
    {
        public static void ConfigureRequestLocalization(this IServiceCollection services)
        {
            var cultures = new CultureInfo[]
            {
                new CultureInfo("en"),
                new CultureInfo("nl"),
                new CultureInfo("fr")
            };

            services.Configure<RequestLocalizationOptions>(ops =>
                {
                    ops.DefaultRequestCulture = new RequestCulture("en");
                    ops.SupportedCultures = cultures.OrderBy(x => x.EnglishName).ToList();
                    ops.SupportedUICultures = cultures.OrderBy(x => x.EnglishName).ToList();

                // add RouteValueRequestCultureProvider to the beginning of the providers list.
                ops.RequestCultureProviders.Insert(0,
                            new RouteValueRequestCultureProvider(cultures, "en"));
                });
        }

        //public static IMvcBuilder AddLocalization<T1, T2>(this IMvcBuilder builder, Action<LocalizationOptions> options)
        //    where T1 : class
        //    where T2 : class
        //{
        //    var localizationOptions = new LocalizationOptions();
        //    options.Invoke(localizationOptions);

        //    var requestLocalizationOptions = new RequestLocalizationOptions();
        //    localizationOptions.RequestLocalizationOptions.Invoke(requestLocalizationOptions);

        //    builder.Services.Configure<RequestLocalizationOptions>(localizationOptions.RequestLocalizationOptions);

        //    return builder
        //        .AddViewLocalization(ops => { ops.ResourcesPath = localizationOptions.ResourcesPath; })
        //        .AddSharedCultureLocalizer<T2>()
        //        .AddDataAnnotationsLocalization<T1>()
        //        .AddModelBindingLocalization<T1>()
        //        .AddIdentityErrorMessagesLocalization<T1>()
        //        .AddRouteValueRequestCultureProvider(requestLocalizationOptions.SupportedCultures, requestLocalizationOptions.DefaultRequestCulture.Culture.Name)
        //        .AddClientSideLocalizationValidationScripts();
        //}

        //public static IMvcBuilder AddSharedCultureLocalizer<T>(this IMvcBuilder builder) where T : class
        //{
        //    builder.Services.AddSingleton<SharedCultureLocalizer>((x) => new SharedCultureLocalizer(x.GetRequiredService<IHtmlLocalizerFactory>(), typeof(T)));

        //    return builder;
        //}

        //public static IMvcBuilder AddRouteValueRequestCultureProvider(this IMvcBuilder builder, IList<CultureInfo> cultures, string defaultCulture)
        //{
        //    builder.Services.Configure<RequestLocalizationOptions>(ops =>
        //    {
        //        ops.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider(cultures, defaultCulture));
        //    });

        //    builder.AddRazorPagesOptions(x =>
        //    {
        //        x.Conventions.Add(new RouteTemplateModelConvention());
        //    });

        //    return builder;
        //}
    }
}
