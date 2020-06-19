using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Quantities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class QuantityServices
    {
        public static IServiceCollection AddQuantityServices(this IServiceCollection services)
        {
            services.AddScoped<IQuantityFactory, QuantityFactory>();
            services.AddScoped<IQuantityModelFactory, QuantityModelFactory>();
            //
            return services;
        }
    }
}
