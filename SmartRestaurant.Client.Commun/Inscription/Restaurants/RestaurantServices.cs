#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetByOwnerId;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Create;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Owners.Queries;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Owners.Services;
using SmartRestaurant.Application.Restaurants.Places.Commands.Create;
using SmartRestaurant.Application.Restaurants.Places.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Places.Commands.Update;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetByAreaId;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetByChainId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Delete;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetById;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Services;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;
using SmartRestaurant.Application.Restaurants.Staffs.Queries;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetChefsByRestaurantIdQuery;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Staffs.Services;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByAreaId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByRestaurantId;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Restaurants
{
    public static class RestaurantServices
    {
        public static IServiceCollection AddAreaServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateAreaCommand, CreateAreaCommand>();
            services.AddScoped<IUpdateAreaCommand, UpdateAreaCommand>();
            services.AddScoped<IDeleteAreaCommand, DeleteAreaCommand>();

            services.AddScoped<IGetAreasByRestaurantIdQuery, GetAreasByRestaurantIdQuery>();
            services.AddScoped<IGetAreasByFloorIdQuery, GetAreasByFloorIdQuery>();
            services.AddScoped<IGetAreaByIdQuery, GetAreaByIdQuery>();

            return services;
        }
        public static IServiceCollection AddMenuServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateMenuCommand, CreateMenuCommand>();
            services.AddScoped<IGetAllMenuFiltredQuery, GetAllMenuFiltredQuery>();
            return services;
        }
        public static IServiceCollection AddChainService(this IServiceCollection services)
        {
            services.AddScoped<ICreateChainCommand, CreateChainCommand>();
            services.AddScoped<IUpdateChainCommand, UpdateChainCommand>();
            services.AddScoped<IDeleteChainCommand, DeleteChainCommand>();
            services.AddScoped<IGetAllChainsQuery, GetAllChainsQuery>();
            services.AddScoped<IGetChainsByOwnerIdQuery, GetChainsByOwnerIdQuery>();
            services.AddScoped<IGetChainByIdQuery, GetChainByIdQuery>();
           
            return services;
        }

        public static IServiceCollection AddTableServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTableCommand, CreateTableCommand>();
            services.AddScoped<IUpdateTableCommand, UpdateTableCommand>();
            services.AddScoped<IDeleteTableCommand, DeleteTableCommand>();

            services.AddScoped<IGetTablesByRestaurantIdQuery, GetTablesByRestaurantIdQuery>();
            services.AddScoped<IGetTablesByFloorIdQuery, GetTablesByFloorIdQuery>();
            services.AddScoped<IGetTablesByAreaIdQuery, GetTablesByAreaIdQuery>();
            services.AddScoped<IGetTableByIdQuery, GetTableByIdQuery>();

            return services;
        }
 public static IServiceCollection AddPlaceServices(this IServiceCollection services)
        {
            services.AddScoped<ICreatePlaceCommand, CreatePlaceCommand>();
            services.AddScoped<IUpdatePlaceCommand, UpdatePlaceCommand>();
            services.AddScoped<IDeletePlaceCommand, DeletePlaceCommand>();

            services.AddScoped<IGetPlacesByRestaurantIdQuery, GetPlacesByRestaurantIdQuery>();
            services.AddScoped<IGetPlacesByAreaIdQuery, GetPlacesByAreaIdQuery>();           
            services.AddScoped<IGetPlaceByIdQuery, GetPlaceByIdQuery>();

            return services;
        }

        public static IServiceCollection AddFloorServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFloorCommand, CreateFloorCommand>();
            services.AddScoped<IUpdateFloorCommand, UpdateFloorCommand>();
            services.AddScoped<IDeleteFloorCommand, DeleteFloorCommand>();

            services.AddScoped<IGetFloorsByRestaurantIdQuery, GetFloorsByRestaurantIdQuery>();
            services.AddScoped<IGetFloorByIdQuery, GetFloorByIdQuery>();

            return services;

        }
        public static IServiceCollection AddRestaurantServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateRestaurantCommand, CreateRestaurantCommand>();
            services.AddScoped<IUpdateRestaurantCommand, UpdateRestaurantCommand>();
            services.AddScoped<IDeleteRestaurantCommand, DeleteRestaurantCommand>();

            services.AddScoped<IGetAllRestaurantsQuery, GetAllRestaurantsQuery>();
            services.AddScoped<IGetRestaurantByIdQuery, GetRestaurantByIdQuery>();
            services.AddScoped<IGetRetaurantBySlugUrlQuery, GetRetaurantBySlugUrlQuery>();
            services.AddScoped<IGetChefsByRestaurantIdQuery, GetChefsByRestaurantIdQuery>();
            services.AddScoped<IGetByRestaurantIdByRoleQuery, GetByRestaurantIdByRoleQuery>();
            return services;
        }

        public static IServiceCollection AddRestaurantTypeServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateRestaurantTypeCommand, CreateRestaurantTypeCommand>();
            services.AddScoped<IUpdateRestaurantTypeCommand, UpdateRestaurantTypeCommand>();
            services.AddScoped<IDeleteRestaurantTypeCommand, DeleteRestaurantTypeCommand>();

            services.AddScoped<IGetRestaurantTypeBySpecificationQuery, GetRestaurantTypeBySpecificationQuery>();
            services.AddScoped<IGetAllRestaurantTypesQuery, GetAllRestaurantTypesQuery>();
            services.AddScoped<IGetRestaurantTypeByIdQuery, GetRestaurantTypeByIdQuery>();
            services.AddScoped<IRestaurantTypeQueries, RestaurantTypeQueries>();
            services.AddScoped<IRestaurantTypeService, RestaurantTypeService>();
            services.AddScoped<IGetRestaurantsByChainIdQuery, GetRestaurantsByChainIdQuery>();
            return services;
        }
        public static IServiceCollection AddOwnerServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOwnerCommand, CreateOwnerCommand>();
            services.AddScoped<IUpdateOwnerCommand, UpdateOwnerCommand>();
            services.AddScoped<IDeleteOwnerCommand, DeleteOwnerCommand>();

            services.AddScoped<IGetOwnerBySpecificationQuery, GetOwnerBySpecificationQuery>();
            services.AddScoped<IGetAllOwnersQuery, GetAllOwnersQuery>();
            services.AddScoped<IGetOwnerByIdQuery, GetOwnerByIdQuery>();
            services.AddScoped<IOwnerQueries, OwnerQueries>();
            services.AddScoped<IOwnerService, OwnerService>();

            return services;
        }

        public static IServiceCollection AddStaffServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateStaffCommand, CreateStaffCommand>();
            services.AddScoped<IUpdateStaffCommand, UpdateStaffCommand>();
            services.AddScoped<IDeleteStaffCommand, DeleteStaffCommand>();

            services.AddScoped<IGetAllStaffsQuery, GetAllStaffsQuery>();
            services.AddScoped<IGetStaffBySpecificationQuery, GetStaffBySpecificationQuery>();
            services.AddScoped<IGetStaffsByRestaurantIdQuery, GetStaffsByRestaurantIdQuery>();
            services.AddScoped<IGetStaffByIdQuery, GetStaffByIdQuery>();
            services.AddScoped<IStaffQueries, StaffQueries>();
            services.AddScoped<IStaffService, StaffService>();
            return services;
        } 
        
    }
}
