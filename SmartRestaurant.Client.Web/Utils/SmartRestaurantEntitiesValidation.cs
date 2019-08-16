using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Commands;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using SmartRestaurant.Application.Commun.Specialites.Commands.Create;
using SmartRestaurant.Application.Commun.Specialites.Commands.Update;
using SmartRestaurant.Application.Commun.Units.Commands.Create;
using SmartRestaurant.Application.Commun.Units.Commands.Update;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Create;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Foods.Validations;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using SmartRestaurant.Application.Templates.Commands.Create;


namespace SmartRestaurant.Client.Web.Utils
{
    public static class SmartRestaurantEntitiesValidation
    {
        public static IServiceCollection AddSmartRestaurantEntitiesFluentValidation(this IServiceCollection services)
        {
            //Class by Ahmed
            services.AddTransient<IValidator<UpdateCountryModel>, UpdateCountryCommandValidation>();
            services.AddTransient<IValidator<UpdateCityModel>, UpdateCityCommandValidation>();
            services.AddTransient<IValidator<UpdateCurrencyModel>, UpdateCurrencyCommandValidation>();
            services.AddTransient<IValidator<UpdateLanguageModel>, UpdateLanguageCommandValidation>();
            services.AddTransient<IValidator<UpdateCountryCurrenciesModel>, UpdateCountryCurrenciesCommandValidation>();
            services.AddTransient<IValidator<CreateTemplateModel>, CreateTemplateCommandValidation>();
            services.AddTransient<IValidator<CreateCountryModel>, CreateCountryCommandValidation>();
            services.AddTransient<IValidator<DeleteCountryModel>, DeleteCountryCommandValidation>();

            services.AddTransient<IValidator<CreateMailingModel>, CreateMailingCommandValidation>();
            services.AddTransient<IValidator<UpdateMailingModel>, UpdateMailCommandValidation>();
            //Class by Yakoub 
            //services.AddTransient<IValidator<UpdateFoodModel>, UpdateFoodCommandValidation>();
            services.AddTransient<IValidator<CreateFoodModel>, CreateFoodCommandValidation>();

            services.AddTransient<IValidator<UpdateProductFamilyModel>, UpdateProductFamilyCommandValidation>();
            services.AddTransient<IValidator<CreateProductFamilyModel>, CreateProductFamilyCommandValidation>();

            services.AddTransient<IValidator<UpdateProductModel>, UpdateProductCommandValidation>();
            services.AddTransient<IValidator<CreateProductModel>, CreateProductCommandValidation>();

            services.AddTransient<IValidator<UpdateStaffModel>, UpdateStaffCommandValidation>();
            services.AddTransient<IValidator<CreateStaffModel>, CreateStaffCommandValidation>();

            services.AddTransient<IValidator<UpdateOwnerModel>, UpdateOwnerCommandValidation>();
            services.AddTransient<IValidator<CreateOwnerModel>, CreateOwnerCommandValidation>();

            services.AddTransient<IValidator<UpdateRestaurantTypeModel>, UpdateRestaurantTypeCommandValidation>();
            services.AddTransient<IValidator<CreateRestaurantTypeModel>, CreateRestaurantTypeCommandValidation>();

            services.AddTransient<IValidator<UpdateRestaurantModel>, UpdateRestaurantCommandValidation>();
            services.AddTransient<IValidator<CreateRestaurantModel>, CreateRestaurantCommandValidation>();

            services.AddTransient<IValidator<UpdateFloorModel>, UpdateFloorCommandValidation>();
            services.AddTransient<IValidator<CreateFloorModel>, CreateFloorCommandValidation>();

            services.AddTransient<IValidator<UpdateAreaModel>, UpdateAreaCommandValidation>();
            services.AddTransient<IValidator<CreateAreaModel>, CreateAreaCommandValidation>();

            services.AddTransient<IValidator<UpdateTableModel>, UpdateTableCommandValidation>();
            services.AddTransient<IValidator<CreateTableModel>, CreateTableCommandValidation>();


            services.AddTransient<IValidator<UpdateAllergyModel>, UpdateAllergyCommandValidation>();
            services.AddTransient<IValidator<CreateAllergyModel>, CreateAllergyCommandValidation>();


            services.AddTransient<IValidator<UpdateIllnessModel>, UpdateIllnessCommandValidation>();
            services.AddTransient<IValidator<CreateIllnessModel>, CreateIllnessCommandValidation>();

            services.AddTransient<IValidator<UpdateTarificationModel>, UpdateTarificationCommandValidation>();
            services.AddTransient<IValidator<CreateTarificationModel>, CreateTarificationCommandValidation>();

            services.AddTransient<IValidator<UpdateChainModel>, UpdateChainCommandValidation>();
            services.AddTransient<IValidator<CreateChainModel>, CreateChainCommandValidation>();


            //class by Ghassan

            #region CreateFood
            services.AddTransient<IValidator<CreateFoodCategoryModel>, CreateFoodCategoryCommandValidation>();
            services.AddTransient<IValidator<UpdateFoodCategoryModel>, UpdateFoodCategoryCommandValidation>();
            #endregion

            #region Food
            services.AddTransient<IValidator<CreateFoodModel>, CreateFoodCommandValidation>();
            services.AddTransient<IValidator<FoodModel>, FoodModelValidation>();
            services.AddTransient<IValidator<IFoodModel>, FoodModelValidation>();
            services.AddTransient<IValidator<INutritionModel>, NutritionModelValidation>();
           
            #endregion

            #region Unit
            services.AddTransient<IValidator<CreateUnitModel>, CreateUnitCommandValidation>();
            services.AddTransient<IValidator<UpdateUnitModel>, UpdateUnitCommandValidation>();
            #endregion

            #region Dishes
            services.AddTransient<IValidator<CreateDishFamilyModel>, CreateDishFamilyModelValidation>();
            services.AddTransient<IValidator<UpdateDishFamilyModel>, UpdateDishFamilyModelValidation>();

            services.AddTransient<IValidator<ICreateDishFamilyModel>, CreateDishFamilyModelValidation>();
            services.AddTransient<IValidator<IUpdateDishFamilyModel>, UpdateDishFamilyModelValidation>();
            #endregion

            #region Specialites
            services.AddTransient<IValidator<CreateSpecialityModel>, CreateSpecialityModelValidation>();
            services.AddTransient<IValidator<UpdateSpecialityModel>, UpdateSpecialityModelValidation>();

            services.AddTransient<IValidator<ICreateSpecialityModel>, CreateSpecialityModelValidation>();
            services.AddTransient<IValidator<IUpdateSpecialityModel>, UpdateSpecialityModelValidation>();
            
            #endregion
            return services;
        }
    }
}
