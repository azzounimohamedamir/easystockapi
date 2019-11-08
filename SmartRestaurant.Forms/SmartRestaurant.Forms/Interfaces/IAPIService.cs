using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Services;
using SmartRestaurant.Application.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Forms.Interfaces
{
    public interface IAPIService
    {
        Task<ServiceModel> GetRestaurantServiceAsync(string restaurantId, EnumLaguangeIso langauge);
        Task<List<TableItemModel>> GetRestaurantTablesAsync(string restaurantId);
        Task<string> GetRestaurantServiceIdAsync(string restaurantId);
        Task<List<LanguageCulture>> GetLanguagesAsync();
    }
}
