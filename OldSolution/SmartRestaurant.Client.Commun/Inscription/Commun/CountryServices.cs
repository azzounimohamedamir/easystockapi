#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Factory;
using SmartRestaurant.Application.Commun.Countries.Queries;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryById;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryByName;
using SmartRestaurant.Application.Commun.Countries.Services;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class CountryServices
    {
        public static IServiceCollection AddCountryServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateCountryCommand, CreateCountryCommand>();
            services.AddScoped<IUpdateCountryCommand, UpdateCountryCommand>();
            services.AddScoped<IDeleteCountryCommand, DeleteCountryCommand>();
            services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateCountryFactory, CreateCountryFactory>();

            services.AddScoped<IGetAllCountriesQuerie, GetAllCountriesQuerie>();
            services.AddScoped<IGetCountryByIdQuerie, GetCountryByIdQuerie>();
            services.AddScoped<IGetCountryByNameQuery, GetCountryByNameQuery>();



            services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
}
