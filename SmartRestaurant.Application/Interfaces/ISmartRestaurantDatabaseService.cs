using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Allergies;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Domain.Products;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ISmartRestaurantDatabaseService
    {
        #region Food
        /// <summary>
        /// Table des aliments
        /// </summary>
        DbSet<Food> Foods { get; set; }
        /// <summary>
        /// Table des catégories d'aliments
        /// </summary>
        DbSet<FoodCategory> FoodCategories { get; set; }

        #endregion

        #region Commun
        DbSet<Picture> Pictures { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<State> States { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Unit> Units { get; set; }
        DbSet<CountryCurrency> CountryCurrencies { get; set; }
        DbSet<Speciality> Specialties { get; set; }
        DbSet<Kitchen> Kitchens { get; set; }
        #endregion


        DbSet<ProductFamily> ProductFamilies { get; }
        DbSet<Product> Products { get; }
        DbSet<Restaurant> Restaurants { get; }
        DbSet<Floor> Floors { get; }
        DbSet<Area> Areas { get; }
        DbSet<Chain> Chains { get; }
        DbSet<Menu> Menus { get; }
        DbSet<Table> Tables { get; }
        DbSet<Staff> Staffs { get; }
        DbSet<Owner> Owners { get; }

        DbSet<Notification> Notifications { get; set; }
        DbSet<Mailing> Mailings { get; set; }
        DbSet<Template> Templates { get; set; }
        DbSet<MailingUser> MailingUsers { get; set; }
        DbSet<NotificationUser> NotificationUsers { get; set; }


        DbSet<Language> Languages { get; }
        DbSet<RestaurantType> RestaurantTypes { get; }
        DbSet<SRUser> SRUsers { get; set; }

        DbSet<Dish> Dishes { get; set; }
        DbSet<DishFamily> DishFamilies { get; set; }
        DbSet<Allergy> Allergies { get; set; }
        DbSet<Illness> Illnesses { get; set; }
        DbSet<Tarification> Tarifications { get; set; }
        DbSet<FoodAllergy> FoodAllergies { get; set; }
        DbSet<FoodIllness> FoodIllnesses { get; set; }
        DbSet<ProductTarification> ProductTarifications { get; set; }
        DbSet<DishTarification> DishTarifications { get; set; }

        DbSet<RestaurantRating> Ratings { get; set; }
        DbSet<Feature> Feature { get; set; }
        DbSet<Meal> Meals { get; set; }
        DbSet<Recommendation> Recommendations { get; set; }

        DbSet<Pricing> Pricings { get; set; }

        DbSet<Place> Places { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Translate> Translates { get; set; }
        DbSet<Section> Sections { get; set; }
        Task<List<T>> SetAsync<T>() where T : class;
        IQueryable<dynamic> Set(Type type);
        void Save();
    }
}