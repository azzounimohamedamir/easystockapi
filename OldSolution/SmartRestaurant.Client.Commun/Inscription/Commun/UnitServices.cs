#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Units.Commands.Create;
using SmartRestaurant.Application.Commun.Units.Commands.Delete;
using SmartRestaurant.Application.Commun.Units.Commands.Factory;
using SmartRestaurant.Application.Commun.Units.Commands.Update;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitById;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class UnitServices
    {
        public static IServiceCollection AddUnitServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateUnitCommand, CreateUnitCommand>();
            services.AddScoped<IUpdateUnitCommand, UpdateUnitCommand>();
            services.AddScoped<IDeleteUnitCommand, DeleteUnitCommand>();
            services.AddScoped<IGetAllUnitsQuerie, GetAllUnitsQuerie>();
            services.AddScoped<IGetUnitByIdQuerie, GetUnitByIdQuerie>();
            services.AddScoped<ICreateUnitFactory, CreateUnitFactory>();
            services.AddScoped<IUpdateUnitFactory, UpdateUnitFactory>();
            return services;
        }
    }
}
