#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Delete;
using SmartRestaurant.Application.Commun.CountryCurrencies.Factory;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrecencyByCountry;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyByCurrency;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyItems;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class CountryCurrencyServices
    {
        public static IServiceCollection AddCountryCurrencyServices(this IServiceCollection services)
        {
            // services.AddScoped<ICreateCountryCurrenciesCommand,CreateCountryCurrenciesCommand>();
            services.AddScoped<IDeleteCountryCurrencyCommand, DeleteCountryCurrencyCommand>();
            services.AddScoped<ICreateCountryCurrenciesFactory, CreateCountryCurrenciesFactory>();

            services.AddScoped<IGetCountryCurrencyByCountryIdQuerie, GetCountryCurrencyByCountryIdQuerie>();
            services.AddScoped<IGetCountryCurrencyByCurrencyIdQuerie, GetCountryCurrencyByCurrencyIdQuerie>();
            services.AddScoped<IGetCountryCurrencyItemsQuerie, GetCountryCurrencyItemsQuerie>();

            return services;
        }

    }
}
