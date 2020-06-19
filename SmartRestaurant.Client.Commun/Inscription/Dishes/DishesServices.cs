using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Factory;
using SmartRestaurant.Application.Dishes.Dishes.Commands;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Create;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Factory;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Update;
using SmartRestaurant.Application.Dishes.Dishes.Queries;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory;

namespace SmartRestaurant.Client.Commun.Inscription.Dishes
{
    public static class DishesServices
    {
        public static IServiceCollection AddDishServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateDishCommand, CreateDishCommand>();
            services.AddScoped<ICreateDishFactory, CreateDishFactory>();
            services.AddScoped<IUpdateDishCommand, UpdateDishCommand>();

            services.AddScoped<IDishFactory, DishFactory>();
            services.AddScoped<IDishAccompanyingFactory, DishAccompanyingFactory>();
            services.AddScoped<IDishEquivalenceFactory, DishEquivalenceFactory>();
            services.AddScoped<IDishIngredientFactory, DishIngredientFactory>();

            services.AddScoped<IGetBySpecificationQuery, GetBySpecificationQuery>();
            services.AddScoped<IGetAllDishQuery, GetAllDishQuery>();
            services.AddScoped<IGetByIdQuery, GetByIdQuery>();

            services.AddScoped<IDishModelFactory, DishModelFactory>();
            services.AddScoped<IDishIngredientModelFactory, DishIngredientModelFactory>();

            services.AddScoped<IDishAccompanimentModelFactory, DishAccompanimentModelFactory>();
            //
            return services;
        }
    }
}
