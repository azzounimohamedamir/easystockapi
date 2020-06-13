#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesBySpecifications;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesList;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilyById;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Dishes
{
    public static class DishFamilyServices
    {
        public static IServiceCollection AddDishFamilyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateDishFamilyFactory, CreateDishFamilyFactory>();
            services.AddScoped<IUpdateDishFamilyFactory, UpdateDishFamilyFactory>();

            services.AddScoped<ICreateDishFamilyCommand, CreateDishFamilyCommand>();
            services.AddScoped<IUpdateDishFamilyCommand, UpdateDishFamilyCommand>();
            services.AddScoped<IDeleteDishFamilyCommand, DeleteDishFamilyCommand>();

            services.AddScoped<IGetDishFamilyByIdQuery, GetDishFamilyByIdQuery>();
            services.AddScoped<IGetDishFamilyListQuery, GetDishFamilyListQuery>();
            services.AddScoped<IGetDishFamilyBySpecificationQuery, GetDishFamilyBySpecificationQuery>();

            services.AddScoped<IGetDishFamilyByRestaurantIdQuery, GetDishFamilyByRestaurantIdQuery>();
            return services;
        }
    }

}
