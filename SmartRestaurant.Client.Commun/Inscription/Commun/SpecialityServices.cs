#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Specialites.Commands.Create;
using SmartRestaurant.Application.Commun.Specialites.Commands.Delete;
using SmartRestaurant.Application.Commun.Specialites.Commands.Factory;
using SmartRestaurant.Application.Commun.Specialites.Commands.Update;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialityById;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesBySpecifications;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesList;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class SpecialityServices
    {
        public static IServiceCollection AddSpecialityServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateSpecialityFactory, CreateSpecialityFactory>();
            services.AddScoped<IUpdateSpecialityFactory, UpdateSpecialityFactory>();

            services.AddScoped<ICreateSpecialityCommand, CreateSpecialityCommand>();
            services.AddScoped<IUpdateSpecialityCommand, UpdateSpecialityCommand>();
            services.AddScoped<IDeleteSpecialityCommand, DeleteSpecialityCommand>();

            services.AddScoped<IGetSpecialityByIdQuery, GetSpecialityByIdQuery>();
            services.AddScoped<IGetSpecialityListQuery, GetSpecialityListQuery>();
            services.AddScoped<IGetSpecialityBySpecificationQuery, GetSpecialityBySpecificationQuery>();

            return services;
        }
    }
}
