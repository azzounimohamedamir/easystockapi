#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Users.Commands.Create;
using SmartRestaurant.Application.Users.Commands.Delete;
using SmartRestaurant.Application.Users.Commands.Update;
using SmartRestaurant.Application.Users.Queries.GetUserById;
using SmartRestaurant.Application.Users.Queries.GetUsersitems;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Configuration
{
    public static class UserServices
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserFactory, CreateUserFactory>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();
            services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
            //   services.AddScoped<ISelectTemplateQuery, SelectCountryQuery>();
            services.AddScoped<IGetUsersItemsQuery, GetUsersItemsQuery>();
            services.AddScoped<IGetUserByIdQuery, GetUserByIdQuery>();

            return services;
        }


    }
}
