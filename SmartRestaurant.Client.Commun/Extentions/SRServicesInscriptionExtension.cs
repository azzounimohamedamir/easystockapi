using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Commun.Inscription;
using SmartRestaurant.Client.Commun.Inscription.Commun;
using SmartRestaurant.Client.Commun.Inscription.Configuration;
using SmartRestaurant.Client.Commun.Inscription.Dishes;
using SmartRestaurant.Client.Commun.Inscription.Foods;
using SmartRestaurant.Client.Commun.Inscription.Restaurants;
using SmartRestaurant.Client.Commun.Inscription.Translates;
using SmartRestaurant.Persistence.ApplicationDataBase;

namespace SmartRestaurant.Client.Commun
{
    public static class SRServicesInscription
    {
        public static IServiceCollection AddSRServices(this IServiceCollection services)
        {
            //TODO: réorganisé l'inscription des services par namespace!
            services.AddScoped<ISmartRestaurantDatabaseService, SmartRestaurantDbContext>();

            services.AddFoodCategoryServices();
            services.AddFoodServices();
            services.AddUnitServices();            

            services.AddQuantityServices();
            services.AddGalleryServices();

            services.AddCountryServices();
            services.AddCityServices();
            services.AddCurrencyServices();
            services.AddStateServices();
            services.AddLanguageServices();
            services.AddTemplateServices();
            services.AddNotificationServices();
            services.AddMailingServices();
            services.AddFloorServices();
            services.AddAreaServices();
            services.AddTableServices();
            services.AddRestaurantServices();
            services.AddRestaurantTypeServices();
            services.AddChainService();
            services.AddOwnerServices();
            services.AddStaffServices();
            services.AddFoodServices();
            services.AddMenuServices();
            //services.AddChainServices(); 
            services.AddProductFamilyServices();
            services.AddProductServices();
           // services.AddRestaurantServices();
            services.AddIllnessServices();
            services.AddAllergyServices();
            services.AddCountryCurrencyServices();
            services.AddUserServices();
            services.AddMailingUserServices();
            services.AddTarificationServices();

            services.AddSpecialityServices();

            services.AddDishFamilyServices();
            services.AddDishServices();
            services.AddPlaceServices();
            services.AddSectionServices();
            services.AddTranslateServices();
            return services;

        }
    }
}
