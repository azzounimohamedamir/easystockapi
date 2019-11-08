#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Countries.Services;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Delete;
using SmartRestaurant.Application.Commun.States.Factory;
using SmartRestaurant.Application.Commun.States.Queries.GetStateByCountry;
using SmartRestaurant.Application.Commun.States.Queries.GetStateById;
using SmartRestaurant.Application.Commun.States.Queries.GetStatesList;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class StateServices
    {
        public static IServiceCollection AddStateServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateStateCommand, CreateStateCommand>();
            services.AddScoped<IUpdateStateCommand, UpdateStateCommand>();
            services.AddScoped<IDeleteStateCommand, DeleteStateCommand>();
            //services.AddScoped<ISelectStateQuery, SelectStateQuery>();
            services.AddScoped<ICreateStateFactory, CreateStateFactory>();

            services.AddScoped<IGetAllStatesQuerie, GetAllStatesQuerie>();
            services.AddScoped<IGetStateByIdQuerie, GetStateByIdQuerie>();
            services.AddScoped<IGetStatesByCountryIdQuerie, GetStatesByCountryIdQuerie>();



            services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
}
