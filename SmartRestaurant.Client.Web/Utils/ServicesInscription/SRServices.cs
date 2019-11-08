#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Delete;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Application.Allergies.Allergies.Queries;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetById;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetBySpecification;
using SmartRestaurant.Application.Allergies.Allergies.Services;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Delete;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Allergies.Illnesses.Queries;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetById;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetBySpesification;
using SmartRestaurant.Application.Allergies.Illnesses.Services;
using SmartRestaurant.Application.Commun.Cities.Commands;
using SmartRestaurant.Application.Commun.Cities.Commands.Factory;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesByStateId;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesList;
using SmartRestaurant.Application.Commun.Cities.Queries.GetCityById;
using SmartRestaurant.Application.Commun.City.Commands.Delete;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Factory;
using SmartRestaurant.Application.Commun.Countries.Queries;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryById;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryByName;
using SmartRestaurant.Application.Commun.Countries.Services;
using SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Delete;
using SmartRestaurant.Application.Commun.CountryCurrencies.Factory;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrecencyByCountry;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyByCurrency;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyItems;
using SmartRestaurant.Application.Commun.Currencies.Commands.Create;
using SmartRestaurant.Application.Commun.Currencies.Commands.Delete;
using SmartRestaurant.Application.Commun.Currencies.Commands.Factory;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyById;
using SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyByName;
using SmartRestaurant.Application.Commun.Languages.Commands.Create;
using SmartRestaurant.Application.Commun.Languages.Commands.Delete;
using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageById;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageByName;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList;
using SmartRestaurant.Application.Commun.Specialites.Commands.Create;
using SmartRestaurant.Application.Commun.Specialites.Commands.Delete;
using SmartRestaurant.Application.Commun.Specialites.Commands.Factory;
using SmartRestaurant.Application.Commun.Specialites.Commands.Update;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialityById;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesBySpecifications;
using SmartRestaurant.Application.Commun.Specialites.Queries.GetSpecialtiesList;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Delete;
using SmartRestaurant.Application.Commun.States.Factory;
using SmartRestaurant.Application.Commun.States.Queries.GetStateByCountry;
using SmartRestaurant.Application.Commun.States.Queries.GetStateById;
using SmartRestaurant.Application.Commun.States.Queries.GetStatesList;
using SmartRestaurant.Application.Commun.Units.Commands.Create;
using SmartRestaurant.Application.Commun.Units.Commands.Delete;
using SmartRestaurant.Application.Commun.Units.Commands.Factory;
using SmartRestaurant.Application.Commun.Units.Commands.Update;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitById;
using SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesBySpecifications;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilliesList;
using SmartRestaurant.Application.Dishes.DishFamillies.Queries.GetDishFamilyById;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.FoodCategories.Queries.GetById;
using SmartRestaurant.Application.FoodCategories.Services;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Commands.Delete;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.FoodCategories.Queries;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.GetBySpecification;
using SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId;
using SmartRestaurant.Application.Foods.Foods.Services;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries.GetById;
using SmartRestaurant.Application.Foods.Queries.GetBySpecification;
using SmartRestaurant.Application.Foods.Services;
using SmartRestaurant.Application.MailingUsers.Commands.Create;
using SmartRestaurant.Application.MailingUsers.Commands.Delete;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserByMailingId;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserItems;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUsersByUserId;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Delete;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Mails.Queries.GelMailingItems;
using SmartRestaurant.Application.Mails.Queries.GetMailingById;
using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Delete;
using SmartRestaurant.Application.Notifications.Commands.Factory;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationById;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationItems;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Delete;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetAll;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Delete;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetById;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Delete;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Application.Products.Products.Queries.GetByFamilyId;
using SmartRestaurant.Application.Products.Products.Queries.GetById;
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
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Owners.Queries;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Owners.Services;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetByChainId;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById;
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
using SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId;
using SmartRestaurant.Application.Restaurants.Staffs.Services;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByAreaId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByFloorId;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Delete;
using SmartRestaurant.Application.Templates.Commands.Factory;
using SmartRestaurant.Application.Templates.Commands.Update;
using SmartRestaurant.Application.Templates.Queries.GetTemplateById;
using SmartRestaurant.Application.Templates.Queries.GetTemplateItems;
using SmartRestaurant.Application.Users.Commands.Create;
using SmartRestaurant.Application.Users.Commands.Delete;
using SmartRestaurant.Application.Users.Commands.Update;
using SmartRestaurant.Application.Users.Queries.GetUserById;
using SmartRestaurant.Application.Users.Queries.GetUsersitems;
#endregion

namespace SmartRestaurant.Client.Web.Utils.ServicesInscription
{
    public static class FoodCategoryServices
    {
        public static IServiceCollection AddFoodCategoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFoodCategoryCommand, CreateFoodCategoryCommand>();
            services.AddScoped<IUpdateFoodCategoryCommand, UpdateFoodCategoryCommand>();
            services.AddScoped<IDeleteFoodCatergoryCommand, DeleteFoodCatergoryCommand>();
            services.AddScoped<IFoodCategoryQueries, FoodCategoryQueries>();

            services.AddScoped<IGetAllFoodCategoriesQuery, GetAllFoodCategoriesQuery>();
            services.AddScoped<IGetFoodCategoryByIdQuery, GetFoodCategoryByIdQuery>();
            services.AddScoped<IGetFoodCategoryBySpecificationQuery, GetFoodCategoryBySpecificationQuery>();

            services.AddScoped<IFoodCategoryService, FoodCategoryService>();

            return services;
        }
    }

    public static class ChainServices
    {
        public static IServiceCollection AddChainServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateChainCommand, CreateChainCommand>();
            services.AddScoped<IUpdateChainCommand, UpdateChainCommand>();
            services.AddScoped<IDeleteChainCommand, DeleteChainCommand>();

            services.AddScoped<IGetAllChainsQuery, GetAllChainsQuery>();
            services.AddScoped<IGetChainByIdQuery, GetChainByIdQuery>();
            services.AddScoped<IGetChainsByOwnerIdQuery, GetChainsByOwnerIdQuery>();

            return services;
        }
    }
    public static class FoodServices
    {
        public static IServiceCollection AddFoodServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFoodCommand, CreateFoodCommand>();
            services.AddScoped<IUpdateFoodCommand, UpdateFoodCommand>();
            services.AddScoped<IDeleteFoodCommand, DeleteFoodCommand>();
            services.AddScoped<IFoodQueries, FoodQueries>();

            services.AddScoped<IGetAllFoodsQuery, GetAllFoodsQuery>();
            services.AddScoped<IGetFoodByIdQuery, GetFoodByIdQuery>();
            services.AddScoped<IGetFoodsByCategoryIdQuery, GetFoodsByCategoryIdQuery>();
            services.AddScoped<IGetFoodBySpecificationQuery, GetFoodBySpecificationQuery>();

            services.AddScoped<IFoodService, FoodService>();

            return services;
        }
    }

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
                        
            return services;
        }
    }    

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
    public static class ProductServices
    {
        public static IServiceCollection AddProductFamilyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductFamilyCommand, CreateProductFamilyCommand>();
            services.AddScoped<IUpdateProductFamilyCommand, UpdateProductFamilyCommand>();
            services.AddScoped<IDeleteProductFamilyCommand, DeleteProductFamilyCommand>();

            services.AddScoped<IGetProductFamilyByIdQuery, GetProductFamilyByIdQuery>();
            services.AddScoped<IGetProductFamiliesByRestaurantIdQuery, GetProductFamiliesByRestaurantIdQuery>();

            return services;
        }
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductCommand, CreateProductCommand>();
            services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();
            services.AddScoped<IDeleteProductCommand, DeleteProductCommand>();

            services.AddScoped<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddScoped<IGetProductByProductFamilyIdQuery, GetProductByProductFamilyIdQuery>();

            return services;
        }
    }
    public static class PricingServices
    {
        public static IServiceCollection AddTarificationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTarificationCommand, CreateTarificationCommand>();
            services.AddScoped<IUpdateTarificationCommand, UpdateTarificationCommand>();
            services.AddScoped<IDeleteTarificationCommand, DeleteTarificationCommand>();

            services.AddScoped<IGetTarificationByIdQuery,  GetTarificationByIdQuery>();
            services.AddScoped<IGetTarificationsByRestaurantIdQuery, GetTarificationsByRestaurantIdQuery>();

            return services;
        }
     }    
    public static class IllnessServices
    {
        public static IServiceCollection AddIllnessServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateIllnessCommand, CreateIllnessCommand>();
            services.AddScoped<IUpdateIllnessCommand, UpdateIllnessCommand>();
            services.AddScoped<IDeleteIllnessCommand, DeleteIllnessCommand>();

            services.AddScoped<IGetIllnessesBySpecificationQuery, GetIllnessesBySpecificationQuery>();
            services.AddScoped<IGetAllIllnessesQuery, GetAllIllnessesQuery>();
            services.AddScoped<IGetIllnessByIdQuery, GetIllnessByIdQuery>();
            services.AddScoped<IIllnessQueries, IllnessQueries>();
            services.AddScoped<IIllnessService, IllnessService>();

            return services;
        }
    }
    public static class AllergyServices
    {
        public static IServiceCollection AddAllergyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateAllergyCommand, CreateAllergyCommand>();
            services.AddScoped<IUpdateAllergyCommand, UpdateAllergyCommand>();
            services.AddScoped<IDeleteAllergyCommand, DeleteAllergyCommand>();

            services.AddScoped<IGetAllergiesBySpecificationQuery, GetAllergiesBySpecificationQuery>();
            services.AddScoped<IGetAllAllergiesQuery, GetAllAllergiesQuery>();
            services.AddScoped<IGetAllergyByIdQuery, GetAllergyByIdQuery>();
            services.AddScoped<IAllergyQueries, AllergyQueries>();
            services.AddScoped<IAllergyService, AllergyService>();

            return services;
        }
    }
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
    public static class LanguageServices
    {
        public static IServiceCollection AddLanguageServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateLanguageCommand, CreateLanguageCommand>();
            services.AddScoped<IUpdateLanguageCommand, UpdateLanguageCommand>();
            services.AddScoped<IDeleteLanguageCommand, DeleteLanguageCommand>();
            //services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateLanguageFactory, CreateLanguageFactory>();

            services.AddScoped<IGetAllLanguagesQuerie, GetAllLanguagesQuerie>();
            services.AddScoped<IGetLanguageByIdQuerie, GetLanguageByIdQuerie>();
            services.AddScoped<IGetLanguageByNameQuerie, GetLanguageByNameQuerie>();



            //services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
    public static class CurrencyServices
    {
        public static IServiceCollection AddCurrencyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateCurrencyCommand, CreateCurrencyCommand>();
            services.AddScoped<IUpdateCurrencyCommand, UpdateCurrencyCommand>();
            services.AddScoped<IDeleteCurrencyCommand, DeleteCurrencyCommand>();
            // services.AddScoped<ISelectCityQuery, SelectCityQuery>();
            services.AddScoped<ICreateCurrencyFactory, CreateCurrencyFactory>();
            services.AddScoped<IGetCurrencyByNameQuerie, GetCurrencyByNameQuerie>();

            services.AddScoped<IGetAllCurrenciesQuery, GetAllCurrenciesQuerie>();
            services.AddScoped<IGetCurrencyByIdQuerie, GetCurrencyByIdQuerie>();
            //services.AddScoped<IGetCitiesByStateIdQuerie, GetCitiesByStateIdQuerie>();

            //    services.AddScoped<IGetCountryByNameQuery, GetCountryByNameQuery>();



            //  services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
    public static class CountryCurrencyServices
    {
        public static IServiceCollection AddCountryCurrencyServices(this IServiceCollection services)
        {
            // services.AddScoped<ICreateCountryCurrenciesCommand,CreateCountryCurrenciesCommand>();
            services.AddScoped<IDeleteCountryCurrencyCommand, DeleteCountryCurrencyCommand>();
            services.AddScoped<ICreateCountryCurrenciesFactory, CreateCountryCurrenciesFactory>();

            services.AddScoped<IGetCountryCurrencyByCountryIdQuerie, GetCountryCurrencyByCountryIdQuerie>();
            services.AddScoped<IGetCountryCurrencyByCurrencyIdQuerie, GetCountryCurrencyByCurrencyIdQuerie>();
            services.AddScoped<IGetCountryCurrencyItemsQuerie, GetCountryCurrencyItemsQuerie>();





            return services;
        }

    }
    public static class TemplateServices
    {
        public static IServiceCollection AddTemplateServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTemplateFactory, CreateTemplateFactory>();
            services.AddScoped<ICreateTemplateCommand, CreateTemplateCommand>();
            services.AddScoped<IUpdateTemplateCommand, UpdateTemplateCommand>();
            services.AddScoped<IDeleteTemplateCommand, DeleteTemplateCommand>();
            //services.AddScoped<ISelectTemplateQuery, SelectCountryQuery>();
            services.AddScoped<IGetAllTemplateQuerie, GetAllTemplateQuerie>();
            services.AddScoped<IGetTemplateByIdQuerie, GetTemplateByIdQuerie>();

            return services;
        }


    }
    public static class NotificationServices
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateNotificationCommand, CreateNotificationCommand>();
            services.AddScoped<IUpdateNotificationCommand, UpdateNotificationCommand>();
            services.AddScoped<IDeleteNotificationCommand, DeleteNotificationCommand>();
            //services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateNotificationFactory, CreateNotificationFactory>();
            services.AddScoped<IGetNotificationItemsQuery, GetNotificationItemsQuerie>();
            services.AddScoped<IGetNotificationByIdQuerie, GetNotificationByIdQuerie>();
            return services;
        }


    }
    public static class MailingServices
    {
        public static IServiceCollection AddMailingServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateMailingCommand, CreateMailingCommand>();
            services.AddScoped<IUpdateMailingCommand, UpdateMailCommand>();
            services.AddScoped<IDeleteMailingCommand, DeleteMailingCommand>();
            //services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateMailingFactory, CreateMailingFactory>();
            services.AddScoped<IGetAllMailingItemsQuerie, GetAllMailingitemsQuerie>();
            services.AddScoped<IGetMailingByIdQuerie, GetMailingByIdQuerie>();
            return services;
        }


    }
    public static class MailingUserServices
    {
        public static IServiceCollection AddMailingUserServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateMailingUserCommand, CreateMailingUserCommand>();
            services.AddScoped<IDeleteMailingUserCommand, DeleteMailingUserCommand>();
            // services.AddScoped<ICreateFactory, CreateCountryCurrenciesFactory>();

            services.AddScoped<IGetMailingUserByMailingIdQuery, GetMailingUserByMailingIdQuery>();
            services.AddScoped<IGetMailingUserByUserIdQuery, GetMailingUserByUserIdQuery>();
            services.AddScoped<IGetMailingUserItemsQuerie, GetMailingUserItemsQuerie>();

            return services;
        }
    }
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
