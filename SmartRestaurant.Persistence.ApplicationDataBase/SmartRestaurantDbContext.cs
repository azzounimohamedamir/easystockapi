using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Allergies;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Domain.Products;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Domain.Services;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Commun;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Dishes;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Foods;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Pricings;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Restaurants;
using SmartRestaurant.Persistence.ApplicationDataBase.Configurations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SmartRestaurant.Persistence.ApplicationDataBase
{
    public class SmartRestaurantDbContext : DbContext, ISmartRestaurantDatabaseService
    {

      
        public SmartRestaurantDbContext(DbContextOptions<SmartRestaurantDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            #region Configuration Commun
            builder.Entity<Language>(new LanguageConfiguration().Configure);
            builder.Entity<Unit>(new UnitConfiguration().Configure);
            builder.Entity<Currency>(new CurrencyConfiguration().Configure);

            builder.Entity<Country>(new CountryConfiguration().Configure);
            builder.Entity<City>(new CityConfiguration().Configure);
            builder.Entity<State>(new StateConfiguration().Configure);
            builder.Entity<CountryCurrency>(new CountryCurrencyConfiguration().Configure);

            builder.Entity<Gallery>(new GalleryConfiguration().Configure);
            builder.Entity<Picture>(new PictureConfiguration().Configure);

            builder.Entity<Domain.Mailing>(new MailingConfiguration().Configure);
            builder.Entity<MailingUser>(new MailingUserConfiguration().Configure);
            builder.Entity<Notification>(new NotificationConfiguration().Configure);
            builder.Entity<NotificationUser>(new NotificationUserConfiguration().Configure);

            builder.Entity<Feature>(new FeatureConfiguration().Configure);
            builder.Entity<Kitchen>(new KitchenConfiguration().Configure);
            builder.Entity<Meal>(new MealConfiguration().Configure);
            builder.Entity<Recommendation>(new RecommendationConfiguration().Configure);
            builder.Entity<PriceType>(new PriceTypeConfiguration().Configure);
            builder.Entity<Translate>(new TranslateConfiguration().Configure);
            #endregion

            #region Configuration Food
            builder.Entity<Food>(new FoodConfiguration().Configure);
            builder.Entity<FoodCategory>(new FoodCategoryConfiguration().Configure);
            builder.Entity<FoodComposition>(new FoodCompositionConfiguration().Configure);
            #endregion

            #region Configuration Dish
            builder.Entity<Dish>(new DishConfiguration().Configure);
            builder.Entity<DishFamily>(new DishFamilyConfiguration().Configure);
            builder.Entity<DishIngredient>(new DishIngredientConfiguration().Configure);
            builder.Entity<DishEquivalence>(new DishEquivalenceConfiguration().Configure);
            #endregion

            #region Configuration Resturant
            //builder.Entity<Menu>(new MenuConfiguration().Configure);
            builder.Entity<Chain>(new ChainConfiguration().Configure);
            builder.Entity<Restaurant>(new RestaurantConfiguration().Configure);
            builder.Entity<Floor>(new FloorConfiguration().Configure);
            builder.Entity<Owner>(new OwnerConfiguration().Configure);
            builder.Entity<Staff>(new StaffConfiguration().Configure);

            builder.Entity<RestaurantRating>(new RatingConfiguration().Configure);
            builder.Entity<RestaurantFeature>(new RestaurantFeatureConfiguration().Configure);
            builder.Entity<RestaurantKitchen>(new RestaurantKitchenConfiguration().Configure);
            builder.Entity<RestaurantMeal>(new RestaurantMealConfiguration().Configure);
            builder.Entity<RestaurantPriceType>(new RestaurantPriceTypeConfiguration().Configure);
            builder.Entity<RestaurantRecommendation>(new RestaurantRecommendationConfiguration().Configure);
            builder.Entity<RestaurantSpecialty>(new RestaurantSpecialtyConfiguration().Configure);

            builder.Entity<Menu>(new MenuConfiguration().Configure);
            builder.Entity<MenuItem>(new MenuItemConfiguration().Configure);
            
            builder.Entity<Service>(new ServiceConfiguration().Configure);
            builder.Entity<ServiceProduct>(new ServiceProductConfiguration().Configure);
            builder.Entity<ServiceState>(new ServiceStateConfiguration().Configure);
            #endregion

            #region Configuration Dish
            builder.Entity<Dish>(new DishConfiguration().Configure);
            builder.Entity<DishAccompanying>(new DishAccompanyingConfiguration().Configure);
            builder.Entity<DishFamily>(new DishFamilyConfiguration().Configure);
            builder.Entity<DishIngredient>(new DishIngredientConfiguration().Configure);
            #endregion

            #region Configuration Pricing
            builder.Entity<Pricing>(new PricingConfiguration().Configure);
            #endregion
        }

        //Migration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Une seule fois juste pour généré la migration
        //  //  optionsBuilder.UseSqlServer(strConnection);
        //}

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CountryCurrency> countryCurrencies { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<SRUser> SRUsers { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Domain.Mailing> Mailings { get; set; }
        public DbSet<MailingUser> MailingUsers { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<FoodIllness> FoodIllnesses { get; set; }
        public DbSet<FoodAllergy> FoodAllergies { get; set; }

        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Tarification> Tarifications { get; set; }
        public DbSet<ProductTarification> ProductTarifications { get; set; }
        public DbSet<DishTarification> DishTarifications { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishFamily> DishFamilies { get; set; }
        public DbSet<Speciality> Specialties { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<RestaurantRating> Ratings { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<Section> Sections { get; set; }
        DbSet<Domain.Mailing> ISmartRestaurantDatabaseService.Mailings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Save()
        {
            this.SaveChanges();
        }

        public async Task<List<T>> SetAsync<T>() where T : class
        {
            return await Set<T>().ToListAsync();
        }

        public IQueryable<dynamic> Set(Type type)  
        {
            return Sett(type);
        }

        public IQueryable<dynamic> Sett (Type type)  
        {

            // Get the generic type definition
            MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

            // Build a method with the specific type argument you're interested in
            method = method.MakeGenericMethod(type);

            return method.Invoke(this, null) as IQueryable<dynamic>;
        }


    }
}
