using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Utils.ServicesInscription;
using SmartRestaurant.Persistence.ApplicationDataBase;

namespace SmartRestaurant.Client.Web.Utils
{
    public static class SmartRestaurantServices
    {
        public static IServiceCollection AddSmartRestaurantServices(this IServiceCollection services)
        {
            services.AddScoped<ISmartRestaurantDatabaseService, SmartRestaurantDbContext>();

            services.AddFoodCategoryServices();
            services.AddFoodServices();
            services.AddUnitServices();

            services.AddDishFamilyServices();

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
            services.AddOwnerServices(); 
            services.AddStaffServices(); 
            services.AddFoodServices(); 
            //services.AddChainServices(); 
            services.AddProductFamilyServices(); 
            services.AddProductServices(); 
            services.AddChainServices();
            services.AddIllnessServices();
            services.AddAllergyServices();
            services.AddCountryCurrencyServices();
            services.AddUserServices();
            services.AddMailingUserServices();
            services.AddTarificationServices();

            services.AddSpecialityServices();
            return services;
           
        }
    }
}
