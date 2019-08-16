#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Cities.Commands;
using SmartRestaurant.Application.Commun.Cities.Commands.Factory;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesByStateId;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesList;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCityById;
using SmartRestaurant.Application.Commun.City.Commands.Delete;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class CityServices
    {
        public static IServiceCollection AddCityServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateCityCommand, CreateCityCommand>();
            services.AddScoped<IUpdateCityCommand, UpdateCityCommand>();
            services.AddScoped<IDeleteCityCommand, DeleteCityCommand>();
            // services.AddScoped<ISelectCityQuery, SelectCityQuery>();
            services.AddScoped<ICreateCityFactory, CreateCityFactory>();

            services.AddScoped<IGetAllCitiesQuerie, GetAllCitiesQuerie>();
            services.AddScoped<IGetCityByIdQuerie, GetCityByIdQuerie>();
            services.AddScoped<IGetCitiesByStateIdQuerie, GetCitiesByStateIdQuerie>();

            //    services.AddScoped<IGetCountryByNameQuery, GetCountryByNameQuery>();



            //  services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
}
