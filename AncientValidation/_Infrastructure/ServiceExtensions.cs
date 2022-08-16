using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Models.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAncientValidation(this IServiceCollection serviceCollection, Action<AncientValidationOptions> options)
        {
            serviceCollection.AddTransient<IAncientValidator, AncientValidator>();
            serviceCollection.AddMvcCore(options =>
            {
                options.Filters.Add(new ValidateFilter());
            });

            var ancientOptions = new AncientValidationOptions();
            options(ancientOptions);

            AncientValidationSingleton.GetInstance().Options = ancientOptions;
            
            return serviceCollection;
        }

        public static IServiceCollection RegisterAncientValidation(this IServiceCollection serviceCollection)
        {
            return RegisterAncientValidation(serviceCollection, options => { });
        }
    }
}
