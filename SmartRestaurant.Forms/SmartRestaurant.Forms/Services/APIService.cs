
using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Services;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Forms.Services
{
    public class APIService : IAPIService
    {
        private const string baseUrl = "http://192.168.43.48:5000/api";
        public APIHelper helper;
        public APIService()
        {
            helper = new APIHelper(baseUrl);
        }
        private APIHelper APIHelper;

        public async Task<ServiceModel> GetRestaurantServiceAsync(string restaurantId, EnumLaguangeIso language)
        {
            return await helper.Get<ServiceModel>("/services/services/" + restaurantId);
        }

        public async Task<List<TableItemModel>> GetRestaurantTablesAsync(string restaurantId)
        {
            return await helper.Get<List<TableItemModel>>("/restaurats/tables/" + restaurantId);

        }

        public Task<string> GetRestaurantServiceIdAsync(string restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LanguageCulture>> GetLanguagesAsync()
        {
            return await helper.Get<List<LanguageCulture>>("/languages/");
        }
    }
}
