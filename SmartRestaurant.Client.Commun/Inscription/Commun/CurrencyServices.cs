#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Currencies.Commands.Create;
using SmartRestaurant.Application.Commun.Currencies.Commands.Delete;
using SmartRestaurant.Application.Commun.Currencies.Commands.Factory;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyById;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyByName;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class CurrencyServices
    {
        public static IServiceCollection AddCurrencyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateCurrencyCommand, CreateCurrencyCommand>();
            services.AddScoped<IUpdateCurrencyCommand, UpdateCurrencyCommand>();
            services.AddScoped<IDeleteCurrencyCommand, DeleteCurrencyCommand>();

            services.AddScoped<ICreateCurrencyFactory, CreateCurrencyFactory>();
            services.AddScoped<IGetCurrencyByNameQuerie, GetCurrencyByNameQuerie>();

            services.AddScoped<IGetAllCurrenciesQuery, GetAllCurrenciesQuerie>();
            services.AddScoped<IGetCurrencyByIdQuerie, GetCurrencyByIdQuerie>();

            return services;
        }

    }
}
